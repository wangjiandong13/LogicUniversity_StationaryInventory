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

        public List<AdjustmentDetail> getAdjVoucherDetail(string adjId)
        {
            //var detail = from x in 
            return null;
        }
    }
}
