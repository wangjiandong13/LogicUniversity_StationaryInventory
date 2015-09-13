using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace BusinessLogic
{
    
    public class AdjustVoucherController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// Get Adjustment Voucher by Date or ID
        /// </summary>
        /// <param name="adjId">AdjustVoucher ID</param>
        /// <param name="startDate">Date</param>
        /// <param name="endDate">Date</param>
        /// <returns>Adjustment Voucher List search by ID, Date</returns>
        public List<AdjustmentVoucher> getAdjVoucher(string adjId,string startDate,string endDate)
        {
            if (adjId == "null")
                adjId = null;
            if (startDate == "null")
                startDate = null;
            if (endDate == "null")
                endDate = null;

            List<AdjustmentVoucher> adjustlist = new List<AdjustmentVoucher>();
            
            if(adjId == null && startDate == null && endDate == null)
            {
                adjustlist = (from x in ctx.AdjustmentVoucher
                              select x).ToList();
            }
            else if(startDate == null && endDate == null)
            {
                adjustlist = (from x in ctx.AdjustmentVoucher
                              where x.AdjID == adjId
                              select x).ToList();
            }
            else if (adjId == null&& startDate != null && endDate != null)
            {
                System.DateTime startDatetime = Convert.ToDateTime(startDate).Date;
                System.DateTime endDatetime = Convert.ToDateTime(endDate).Date;
                adjustlist = (from x in ctx.AdjustmentVoucher
                              where x.Date >= startDatetime && x.Date <= endDatetime
                              select x).ToList();
            }
            else
            {
                adjustlist = (from x in ctx.AdjustmentVoucher
                              where x.AdjID == adjId
                              select x).ToList();
            }
             

            return adjustlist;
        }

        /// <summary>
        /// Get Adjustment Detail by AdjustmentVoucher ID
        /// </summary>
        /// <param name="adjId">Adjustment Voucher ID</param>
        /// <returns>AdjustmentDetail List by AdjID</returns>
        public List<AdjustmentDetail> getAdjVoucherDetail(string adjId)
        {
            var detail = from x in ctx.AdjustmentDetail
                         where x.AdjID == adjId
                         select x;
            return detail.ToList();
        }

        /// <summary>
        /// Get new Adjustment Voucher ID
        /// </summary>
        /// <returns>New Adj ID</returns>
        public string getAdjVoucherId()
        {
            AdjustmentVoucher adj = new AdjustmentVoucher();
            adj = (from a in ctx.AdjustmentVoucher
                   orderby a.AdjID descending
                   select a).First();
            
            string oldID = adj.AdjID; //001/09/2015
            string oldno = oldID.Substring(0, 3); //001
            string oldmonth = oldID.Substring(4, 2); //09
            int oldmonth_Int = Convert.ToInt32(oldmonth);//09 --> 9
            string month = DateTime.Now.Month.ToString();//09
            string year = DateTime.Now.Year.ToString();
            int oldno_Int = Convert.ToInt32(oldno);// 01 --> 1
            string d = Convert.ToString(oldno_Int + 1);
            string newID = "";
            if (oldmonth_Int == Convert.ToInt32(month)) // 9 == 9
            {

                if (Convert.ToInt32(oldmonth) < 10)
                    month = "0" + month;

                d = d.PadLeft(3, '0');
                newID = d + "/" + month + "/" + year;
            }
            else
            {
                if (Convert.ToInt32(month) < 10)
                    month = "0" + month;
                newID = "001" + "/" + month + "/" + year;
            }

            return newID;
        }

        /// <summary>
        /// CreateVoucherAdj
        /// </summary>
        /// <param name="adj">AdjustVoucher Object (ReportedBy, Status)</param>
        /// <returns>True or False</returns>
        public bool createVoucherAdj(AdjustmentVoucher adj)
        {
            bool result = true;
            //double totAmt = 0.0;

            string newID = getAdjVoucherId();
            adj.AdjID = newID;
            adj.Date = DateTime.Now;
            ctx.AdjustmentVoucher.Add(adj);

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
        /// CreateVoucherAdjDetail
        /// </summary>
        /// <param name="adjDetail">AdjustVoucherDetail Object (ItemCode, Qty, Reason, Remark)</param>
        /// <returns>True or False</returns>
        public bool createVoucherAdjDetail(List<AdjustmentDetail> adjDetail)
        {
            bool result = true;
            double totAmt = 0.0;

            AdjustmentVoucher adj = ctx.AdjustmentVoucher.ToList().Last();

            foreach (AdjustmentDetail adjVoucher in adjDetail)
            {
                Supplier s = ctx.Supplier.Where(x => x.Rank == 1).FirstOrDefault();
                string supID = s.SupplierID;
                ItemPrice i = ctx.ItemPrice.Where(x => x.ItemID == adjVoucher.ItemID && x.SupplierID == supID).FirstOrDefault();
                adjVoucher.Price = i.Price;
                adjVoucher.AdjID = adj.AdjID;
                
                ctx.AdjustmentDetail.Add(adjVoucher);

                totAmt += Convert.ToDouble(adjVoucher.Price) * Convert.ToDouble(adjVoucher.Qty);
            }

            adj.TotalAmt = totAmt;

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            if (result == true)
            {
                //send notification:
                NotificationController nt = new NotificationController();
                nt.sendNotification(7, Convert.ToInt32(adj.ReportedBy), adj.AdjID);
            }

            return result;
        }

        /// <summary>
        /// ApproveAdj
        /// </summary>
        /// <param name="AdjID">AdjustmentVoucher ID</param>
        /// <returns>true or false</returns>
        public bool approveAdj(string AdjID, string ApprovedBy)
        {
            bool result = true;

            //change status of adj voucher to approve
            AdjustmentVoucher adjvoucher = (from x in ctx.AdjustmentVoucher
                          where x.AdjID == AdjID
                          select x).First();
            adjvoucher.Status = "APPROVED";
            adjvoucher.ApprovedBy = Convert.ToInt32(ApprovedBy);
            
            List<AdjustmentDetail> adjDetailList = (from l in ctx.AdjustmentDetail
                        where l.AdjID == AdjID
                        select l).ToList();

            foreach(AdjustmentDetail adjDetail in adjDetailList)
            {
                string itemID = adjDetail.ItemID;

                //update stock card
                List<StockCard> stockCardList = ctx.StockCard.Where(x => x.ItemID == itemID).ToList();
                int balance = 0;
                if (stockCardList.FirstOrDefault() != null)
                    balance = (int)stockCardList.Last().Balance;

                StockCard stockCard = new StockCard();
                stockCard.ItemID = itemID;
                stockCard.Date = DateTime.Now;
                stockCard.Description = "Stock Adjustment " + AdjID;
                stockCard.Qty = adjDetail.Qty;
                stockCard.Balance = balance + adjDetail.Qty;
                ctx.StockCard.Add(stockCard);
                
                //update stock in item
                Item item = ctx.Item.Where(x => x.ItemID == itemID).FirstOrDefault();
                item.Stock = balance + adjDetail.Qty;
            }

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            if (result == true)
            {
                //send notification:
                NotificationController nt = new NotificationController();
                nt.sendNotification(8, Convert.ToInt32(adjvoucher.ReportedBy), adjvoucher.AdjID);
            }

            return result;

        }

        /// <summary>
        /// RejectAdj
        /// </summary>
        /// <param name="AdjID">AdjustmentVoucher ID</param>
        /// <returns>true or false</returns>
        public bool rejectAdj(string AdjID, string ApprovedBy)
        {
            bool result = true;

            //change status of adj voucher to reject
            AdjustmentVoucher adjvoucher = (from x in ctx.AdjustmentVoucher
                            where x.AdjID == AdjID
                            select x).First();
            adjvoucher.Status = "REJECT";
            adjvoucher.ApprovedBy = Convert.ToInt32(ApprovedBy);

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            if (result == true)
            {
                //send notification:
                NotificationController nt = new NotificationController();
                nt.sendNotification(9, Convert.ToInt32(adjvoucher.ReportedBy), adjvoucher.AdjID);
            }

            return result;

        }
    }
}
