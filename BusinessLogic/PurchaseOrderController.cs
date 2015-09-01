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

        public List<PurchaseOrder> getPo(DateTime startDate, DateTime endDate, string EmpID, string PoID)
        {
            if (EmpID == null)
                EmpID = "";
            if (PoID == null)
                PoID = "";
            
            List<PurchaseOrder> result = ctx.PurchaseOrder
                .Where(x=> x.Date > startDate && x.Date < endDate)
                .Where(x => x.EmpID == EmpID)
                .Where(x => x.PoID == PoID)
                .ToList();

            return result;
        }

        public List<PurchaseOrderDetail> getPoDetail(string PoID)
        {
            List<PurchaseOrderDetail> result = ctx.PurchaseOrderDetail
                .Where(x => x.PoID == PoID)
                .ToList();

            return result;
        }
        
        public bool restock(string PoID)
        {
            
        }

    }

}


