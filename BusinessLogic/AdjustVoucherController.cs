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

        public List<AdjustmentVoucher> getAdjVoucherList(string adjId)
        {
            AdjustmentVoucher adjlist = new AdjustmentVoucher();

           // adjlist = from x in ctx.AdjustmentVoucher


            return null;
        }
    }
}
