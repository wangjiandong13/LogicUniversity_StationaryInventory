using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    class PurchaseOrderController
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
        //public List<PurchaseOrder> getPo(DateTime startDate, DateTime endDate, int EmpID, int PoID)
        //{
        //    if (EmpID == null)
        //        EmpID = "";
        //    if (PoID == 0)
        //        PoId = null;
            
        //    List<PurchaseOrder> result = ctx.PurchaseOrder
        //        .Where(x=> x.Date > startDate && x.Date < endDate)
        //        .Where(x => x.EmpID == EmpID)
        //        .Where(x => x.PoID == PoID)
        //        .ToList();

        //    return result;
        //}

        /// <summary>
        /// GetPoDetail
        /// </summary>
        /// <param name="PoID">Purchase Order ID</param>
        /// <returns></returns>
        public List<PurchaseOrderDetail> getPoDetail(int PoID)
        {
            List<PurchaseOrderDetail> result = ctx.PurchaseOrderDetail
                .Where(x => x.PoID == PoID)
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
            bool result = false;
            
            //Update the actual qty for every poDetail
            foreach(PurchaseOrderDetail poDetail in PoDetailList)
            {
                PurchaseOrderDetail poDetailSearch = ctx.PurchaseOrderDetail
                    .Where(x => x.PoID == poDetail.PoID && x.ItemID == poDetail.ItemID)
                    .FirstOrDefault();

                poDetailSearch.ActualQty = poDetail.ActualQty;
            }

            //change status of purchase order to "Delivered"
            PurchaseOrder po = ctx.PurchaseOrder.Where(x => x.PoID == PoDetailList.First().PoID).First();
            po.Status = "Delivered";
            
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

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
            bool result = false;

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
                po.EstDate = supplier1.First().EstDate;
                po.Status = "Pending";
                ctx.PurchaseOrder.Add(po);

                //obtain the PoID of the newly added Po
                int poLastID = ctx.PurchaseOrder.Last().PoID;
       
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
                ctx.PurchaseOrder.Last().TotalAmt = totalamt;
            }

            //generate po for supplier 2
            if (supplier2.FirstOrDefault() != null)
            {
                //create and add new po to db
                PurchaseOrder po = new PurchaseOrder();
                po.SupplierID = supplier1ID;
                po.EmpID = supplier2.First().EmpID;
                po.Date = DateTime.Now;
                po.EstDate = supplier2.First().EstDate;
                po.Status = "Pending";
                ctx.PurchaseOrder.Add(po);

                //obtain the PoID of the newly added Po
                int poLastID = ctx.PurchaseOrder.Last().PoID;

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
                ctx.PurchaseOrder.Last().TotalAmt = totalamt;
            }

            //generate po for supplier 3
            if (supplier2.FirstOrDefault() != null)
            {
                //create and add new po to db
                PurchaseOrder po = new PurchaseOrder();
                po.SupplierID = supplier1ID;
                po.EmpID = supplier3.First().EmpID;
                po.Date = DateTime.Now;
                po.EstDate = supplier3.First().EstDate;
                po.Status = "Pending";
                ctx.PurchaseOrder.Add(po);

                //obtain the PoID of the newly added Po
                int poLastID = ctx.PurchaseOrder.Last().PoID;

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
                ctx.PurchaseOrder.Last().TotalAmt = totalamt;
            }

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }
       
    }

}


