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
        
        public bool restock(PurchaseOrderDetail PoDetail)
        {
            bool result = false;

            ctx.PurchaseOrderDetail.Add(PoDetail);
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        public List<ProposePo> propose()
        {
            //retrieve items that are low on stock
            List<Item> items = ctx.Item.Where(x => x.Stock < x.RoLvl).ToList();

            List<ProposePo> poList = new List<ProposePo>();

            // format to ProposePo class
            foreach (Item i in items)
            {
                ProposePo po = new ProposePo();
                po.ItemID = i.ItemID;
                po.ItemName = i.ItemName;
                po.totalQty = i.RoQty;
                po.supplier1Qty = i.RoQty;

                poList.Add(po);
            }

            return poList;
        }

       
    }

}


