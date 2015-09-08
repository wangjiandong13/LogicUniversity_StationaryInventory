﻿using System;
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
        public List<AdjustmentVoucher> getAdjVoucher(string adjId,string startDate,string endDate)
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
                              where x.Date == Convert.ToDateTime(startDate).Date && x.Date == Convert.ToDateTime(endDate).Date
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
        /// <param name="adj">AdjustVoucher Object</param>
        /// <returns>True or False</returns>
        public bool createVoucherAdj(AdjustmentVoucher adj)
        {
            bool result = true;
            //double totAmt = 0.0;

            string newID = getAdjVoucherId();
            adj.AdjID = newID;
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

            AdjustmentVoucher adj = ctx.AdjustmentVoucher.Last();

            AdjustmentDetail adjVoucherDetail = new AdjustmentDetail();
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

            return result;
        }

        /// <summary>
        /// ApproveAdj
        /// </summary>
        /// <param name="AdjID">AdjustmentVoucher ID</param>
        /// <returns>true or false</returns>
        public bool approveAdj(string AdjID)
        {
            bool result = true;

            //change status of adj voucher to approve
            AdjustmentVoucher adjvoucher = (from x in ctx.AdjustmentVoucher
                          where x.AdjID == AdjID
                          select x).First();
            adjvoucher.Status = "APPROVED";

            //update stock card, adjust qty
            var list = (from l in ctx.AdjustmentDetail
                        where l.AdjID == AdjID
                        select l).ToList();

            for(int i=0;i<list.Count;i++)
            {
                Item item = (from a in ctx.Item
                        where a.ItemID == list[i].ItemID
                        select a).First();
                item.Stock += list[i].Qty;

                StockCard sc = new StockCard();
                sc.ItemID = item.ItemID;
                sc.Date = System.DateTime.Now;
                sc.Description = "Stock Adjustment " + AdjID;
                sc.Qty = list[i].Qty;
                sc.Balance = item.Stock;
                ctx.StockCard.Add(sc);
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

        /// <summary>
        /// RejectAdj
        /// </summary>
        /// <param name="AdjID">AdjustmentVoucher ID</param>
        /// <returns>true or false</returns>
        public bool rejectAdj(string AdjID)
        {
            bool result = true;

            //change status of adj voucher to reject
            AdjustmentVoucher adjvoucher = (from x in ctx.AdjustmentVoucher
                            where x.AdjID == AdjID
                            select x).First();
            adjvoucher.Status = "REJECT";

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
