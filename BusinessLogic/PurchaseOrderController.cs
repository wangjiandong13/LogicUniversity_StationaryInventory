using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class PurchaseOrderController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// GetPo
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <param name="EmpID">Employee ID</param>
        /// <param name="PoID">Purchase Order ID</param>
        /// <returns></returns>
        public List<PurchaseOrder> getPo(string startdate, string enddate, string EmpID, string PoID)
        {
            if (startdate == "null")
                startdate = null;
            if (enddate == "null")
                enddate = null;
            if (EmpID == "null")
                EmpID = null;
            if (PoID == "null")
                PoID = null;

            //start with all the records
            var query = from po in ctx.PurchaseOrder select po;

            //filter the result set based on user inputs
            if (!string.IsNullOrEmpty(EmpID))
            {
                query = query.Where(x => x.EmpID.ToString().Contains(EmpID));
            }
            if (!string.IsNullOrEmpty(PoID))
            {
                query = query.Where(x => x.PoID.ToString().Contains(PoID));
            }
            if (!string.IsNullOrEmpty(startdate))
            {
                DateTime sd = Convert.ToDateTime(startdate).Date;
                query = query.Where(x => x.Date >= sd);
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                DateTime ed = Convert.ToDateTime(enddate).Date;
                query = query.Where(x => x.Date <= ed);
            }

            //run the query on database and grab the results
            return query.ToList();
        }

        /// <summary>
        /// GetPoDetail
        /// </summary>
        /// <param name="PoID">Purchase Order ID</param>
        /// <returns></returns>
        public List<PurchaseOrderDetail> getPoDetail(string PoID)
        {
            int poID = Convert.ToInt32(PoID);
            List<PurchaseOrderDetail> result = ctx.PurchaseOrderDetail
                .Where(x => x.PoID == poID)
                .ToList();

            return result;
        }

        /// <summary>
        /// Restock
        /// </summary>
        /// <param name="PoDetailList">PoDetailList(PoID, ItemID, ActualQty)</param>
        /// <returns></returns>
        public bool restock(List<PurchaseOrderDetail> PoDetailList)
        {
            bool result = true;

            //search for purchase order to obtain supplier ID
            int poID = (int)PoDetailList.First().PoID; 
            PurchaseOrder po = ctx.PurchaseOrder.Where(x => x.PoID == poID).FirstOrDefault();

            foreach(PurchaseOrderDetail poDetail in PoDetailList)
            {
                //Update the actual qty for every poDetail
                PurchaseOrderDetail poDetailSearch = ctx.PurchaseOrderDetail
                    .Where(x => x.PoID == poDetail.PoID && x.ItemID == poDetail.ItemID)
                    .FirstOrDefault();

                poDetailSearch.ActualQty = poDetail.ActualQty;

                //update stock card
                List<StockCard> stockCardList = ctx.StockCard.Where(x => x.ItemID == poDetail.ItemID).ToList();
                int balance = 0;
                if (stockCardList.FirstOrDefault() != null)
                    balance = (int)stockCardList.Last().Balance;

                StockCard stockCard = new StockCard();
                stockCard.ItemID = poDetail.ItemID;
                stockCard.Date = DateTime.Now;
                stockCard.Description = "Supplier - " + po.SupplierID;
                stockCard.Qty = poDetail.ActualQty;
                stockCard.Balance = balance + poDetail.ActualQty;
                ctx.StockCard.Add(stockCard);

                //update stock in item
                Item item = ctx.Item.Where(x => x.ItemID == poDetail.ItemID).FirstOrDefault();
                item.Stock = balance + poDetail.ActualQty;
            }

            //change status of purchase order to "Delivered"
            po.Status = "DELIVERED";

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Propose
        /// </summary>
        /// <returns></returns>
        public List<ProposePo> propose()
        {
            //retrieve items that are low on stock
            List<Item> items = ctx.Item.Where(x => x.Stock < x.RoLvl).ToList();

            List<ProposePo> proposePoList = new List<ProposePo>();

            // format to ProposePo class
            foreach (Item i in items)
            {
                ProposePo po = new ProposePo();
                po.ItemID = i.ItemID;
                po.ItemName = i.ItemName;
                po.totalQty = (int)i.RoQty;
                po.supplier1Qty = (int)i.RoQty;
                po.supplier2Qty = 0;
                po.supplier3Qty = 0;

                proposePoList.Add(po);
            }

            return proposePoList;
        }

        /// <summary>
        /// GeneratePo
        /// </summary>
        /// <param name="proposePoList">proposePoList(EmpID, EstDate, ItemID, supplier1Qty, supplier2Qty, supplier3Qty)</param>
        /// <returns></returns>
        public bool generatePo(List<ProposePo> proposePoList)
        {
            bool result = true;

            //filter the proposePoList by supplier
            List<ProposePo> supplier1 = proposePoList.Where(x => x.supplier1Qty != 0).ToList();
            List<ProposePo> supplier2 = proposePoList.Where(x => x.supplier2Qty != 0).ToList();
            List<ProposePo> supplier3 = proposePoList.Where(x => x.supplier3Qty != 0).ToList();

            //obtain supplier1 ID
            string supplier1ID = ctx.Supplier.Where(x => x.Rank == 1).First().SupplierID;
            //obtain supplier2 ID
            string supplier2ID = ctx.Supplier.Where(x => x.Rank == 2).First().SupplierID;
            //obtain supplier3 ID
            string supplier3ID = ctx.Supplier.Where(x => x.Rank == 3).First().SupplierID;

            //generate po for supplier 1
            if (supplier1.FirstOrDefault() != null)
            {
                //create and add new po to db
                PurchaseOrder po = new PurchaseOrder();
                po.SupplierID = supplier1ID;
                po.EmpID = supplier1.First().EmpID;
                po.Date = DateTime.Now;
                po.EstDate = Convert.ToDateTime(supplier1.First().EstDate).Date;
                po.Status = "PENDING";
                ctx.PurchaseOrder.Add(po);

                //obtain the PoID of the newly added Po
                int empID = supplier1.First().EmpID;
                var poLast = ctx.PurchaseOrder.Where(x=> x.EmpID == empID).ToList().Last();
                int poLastID = poLast.PoID;
       
                double totalamt = 0;

                //create and add poDetail to db
                foreach (ProposePo proposepo in proposePoList)
                {
                    PurchaseOrderDetail poDetail = new PurchaseOrderDetail();
                    poDetail.PoID = poLastID;
                    poDetail.ItemID = proposepo.ItemID;
                    poDetail.Qty = proposepo.supplier1Qty;
                    poDetail.Price = ctx.ItemPrice.Where(x => x.ItemID == proposepo.ItemID).First().Price;
                    ctx.PurchaseOrderDetail.Add(poDetail);
                    totalamt += Convert.ToDouble(poDetail.Qty) * (double)poDetail.Price;
                }

                //Update the po total amount
                poLast.TotalAmt = totalamt;
            }

            //generate po for supplier 2
            if (supplier2.FirstOrDefault() != null)
            {
                //create and add new po to db
                PurchaseOrder po = new PurchaseOrder();
                po.SupplierID = supplier2ID;
                po.EmpID = supplier2.First().EmpID;
                po.Date = DateTime.Now;
                po.EstDate = Convert.ToDateTime(supplier2.First().EstDate);
                po.Status = "PENDING";
                ctx.PurchaseOrder.Add(po);

                //obtain the PoID of the newly added Po
                int empID = supplier2.First().EmpID;
                var poLast = ctx.PurchaseOrder.Where(x => x.EmpID == empID).ToList().Last();
                int poLastID = poLast.PoID;

                double totalamt = 0;

                //create and add poDetail to db
                foreach (ProposePo proposepo in proposePoList)
                {
                    PurchaseOrderDetail poDetail = new PurchaseOrderDetail();
                    poDetail.PoID = poLastID;
                    poDetail.ItemID = proposepo.ItemID;
                    poDetail.Qty = proposepo.supplier2Qty;
                    poDetail.Price = ctx.ItemPrice.Where(x => x.ItemID == proposepo.ItemID).First().Price;
                    ctx.PurchaseOrderDetail.Add(poDetail);
                    totalamt += Convert.ToDouble(poDetail.Qty) * (double)poDetail.Price;
                }

                //Update the po total amount
                poLast.TotalAmt = totalamt;
            }

            //generate po for supplier 3
            if (supplier3.FirstOrDefault() != null)
            {
                //create and add new po to db
                PurchaseOrder po = new PurchaseOrder();
                po.SupplierID = supplier3ID;
                po.EmpID = supplier3.First().EmpID;
                po.Date = DateTime.Now;
                po.EstDate = Convert.ToDateTime(supplier3.First().EstDate);
                po.Status = "PENDING";
                ctx.PurchaseOrder.Add(po);

                //obtain the PoID of the newly added Po
                int empID = supplier3.First().EmpID;
                var poLast = ctx.PurchaseOrder.Where(x => x.EmpID == empID).ToList().Last();
                int poLastID = poLast.PoID;

                double totalamt = 0;

                //create and add poDetail to db
                foreach (ProposePo proposepo in proposePoList)
                {
                    PurchaseOrderDetail poDetail = new PurchaseOrderDetail();
                    poDetail.PoID = poLastID;
                    poDetail.ItemID = proposepo.ItemID;
                    poDetail.Qty = proposepo.supplier3Qty;
                    poDetail.Price = ctx.ItemPrice.Where(x => x.ItemID == proposepo.ItemID).First().Price;
                    ctx.PurchaseOrderDetail.Add(poDetail);
                    totalamt += Convert.ToDouble(poDetail.Qty) * (double)poDetail.Price;
                }

                //Update the po total amount
                poLast.TotalAmt = totalamt;
            }

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }
       
    }

}


