using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    class RequisitionController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        public List<Requisition> getRequisitionList(string DisID)
        {
            List<Requisition> result = ctx.Requisition.Where(x => x.DisID == DisID).ToList();

            return result;
        }

        public bool approve(string ReqId, string HandledBy, string Remark)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqId).FirstOrDefault();
            req.HandledBy = HandledBy;
            req.Remark = Remark;

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

    }
}
