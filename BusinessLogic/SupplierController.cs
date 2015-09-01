using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class SupplierController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        public List<Supplier> getSupplierList()
        {
            var supplierlist = from s in ctx.Supplier
                               select s;

            return supplierlist.ToList();
        }

        public List<Supplier> getBySupplierID(string supplierid)
        {
            var sl = from s in ctx.Supplier
                     where s.SupplierID == supplierid
                     select s;

            return sl.ToList();
        }

        public bool createSupplier(string supplierId, string supplierName, string contact,int regno, string phone, string address, string fax)
        {
            Supplier s = new Supplier();
            s.SupplierID = supplierId;
            s.SupplierName = supplierName;
            s.Contact = contact;
            s.RegNo = regno;
            s.Phone = phone;
            s.Address = address;
            s.Fax = fax;
            s.Rank = "4";

            ctx.Supplier.Add(s);
            ctx.SaveChanges();

            return true;
        }
    }
}
