using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
        public List<AdjustmentVoucher> getAdjVoucher(string adjId,DateTime startDate,DateTime endDate)
        {
            List<AdjustmentVoucher> adjustlist = new List<AdjustmentVoucher>();
            
            if(adjId == null && startDate == null && endDate == null)
            {
                adjustlist = (from x in ctx.AdjustmentVoucher
                              select x).ToList();
            }
            else if(startDate == null && endDate == null)
            {
                adjustlist = (from x in ctx.AdjustmentVoucher
                              where x.Date == startDate && x.Date == endDate
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
        /// Create Ajustment Voucher
        /// </summary>
        /// <param name="adj">AdjustVoucher Object</param>
        /// <param name="adjDetail">AdjustVoucherDetail Object</param>
        /// <returns>True or False</returns>
        public bool createVoucher(AdjustmentVoucher adj, List<AdjustmentDetail> adjDetail)
        {
            double totAmt = 0.0;

            string newID = getAdjVoucherId();
            adj.AdjID = newID;
            ctx.AdjustmentVoucher.Add(adj);

            AdjustmentDetail adjVoucherDetail = new AdjustmentDetail();
            foreach(AdjustmentDetail adjVoucher in adjDetail)
            {
                ctx.AdjustmentDetail.Add(adjVoucher);                
            }

            return true;
        }

        /// <summary>
        /// Update Item qty according to Adjustment Approval
        /// </summary>
        /// <param name="adj">AdjustmentVoucher Object</param>
        /// <param name="adjDetail">AdjustmentDetail Object</param>
        /// <param name="status">Status</param>
        /// <returns>true or false</returns>
        public bool updateAdjustmentDetail(AdjustmentVoucher adj, List<AdjustmentDetail> adjDetail, string status)
        {
            AdjustmentVoucher adjvoucher = new AdjustmentVoucher();
            Item item = new Item();
            StockCard sc = new StockCard();

            if(status == "Approve")
            {
                var list = (from l in ctx.AdjustmentDetail
                           where l.AdjID == adj.AdjID
                           select l).ToList();

                for(int i=0;i<list.Count;i++)
                {
                    item = (from a in ctx.Item
                            where a.ItemID == list[i].ItemID
                            select a).First();
                    item.Stock += list[i].Qty;                    
                    ctx.SaveChanges();
                    sc.ItemID = item.ItemID;
                    sc.Date = System.DateTime.Now;
                    sc.Description = "Stock Adjustment " + adj.AdjID;
                    sc.Qty = list[i].Qty;
                    sc.Balance = item.Stock;
                    ctx.StockCard.Add(sc);
                    ctx.SaveChanges();
                }

            }
            else
            {
                adjvoucher = (from x in ctx.AdjustmentVoucher
                              where x.AdjID == adj.AdjID
                              select x).First();
                adjvoucher.Status = "Reject";
                ctx.SaveChanges();
            }

            return true;

        }
    }
}
