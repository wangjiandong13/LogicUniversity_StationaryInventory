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
        /// <returns></returns>
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
        /// <param name="adjId"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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

        public bool createVoucher(AdjustmentVoucher adj, List<AdjustmentDetail> adjDetail)
        {
            return true;
        }
    }
}
