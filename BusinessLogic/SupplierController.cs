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

        /// <summary>
        /// GetAllSupplierList
        /// </summary>
        /// <returns></returns>
        public List<Supplier> getSupplierList()
        {
            var supplierlist = from s in ctx.Supplier
                               select s;

            return supplierlist.ToList();
        }

        /// <summary>
        /// GetBySupplierID
        /// </summary>
        /// <param name="supplierid">Supplier ID</param>
        /// <returns></returns>
        public Supplier getBySupplierID(string supplierid)
        {
            var sl = (from s in ctx.Supplier
                     where s.SupplierID == supplierid
                     select s).First();

            return (Supplier)sl;
        }

        /// <summary>
        /// Create/UpdateSupplier
        /// </summary>
        /// <param name="supplierId">Supplier ID</param>
        /// <param name="supplierName">Supplier Name</param>
        /// <param name="contact">Contact Person Name</param>
        /// <param name="regno">Reg No</param>
        /// <param name="phone">Phone</param>
        /// <param name="address">Address</param>
        /// <param name="fax">Fax</param>
        /// <returns></returns>
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

        /// <summary>
        /// Update Supplier Info
        /// </summary>
        /// <param name="supplierId">Supplier ID</param>
        /// <param name="supplierName">Supplier Name</param>
        /// <param name="contact">Contact Person Name</param>
        /// <param name="regno">Reg No</param>
        /// <param name="phone">Phone</param>
        /// <param name="address">Address</param>
        /// <param name="fax">Fax</param>
        /// <returns></returns>
        public bool updateSupplier(string supplierId, string supplierName, string contact, int regno, string phone, string address, string fax)
        {
            Supplier s = new Supplier();
            s = (from x in ctx.Supplier
                where x.SupplierID == supplierId
                select x).First();
            s.SupplierID = supplierId;
            s.SupplierName = supplierName;
            s.Contact = contact;
            s.RegNo = regno;
            s.Phone = phone;
            s.Address = address;
            s.Fax = fax;
            

            
            ctx.SaveChanges();

            return true;
        }

        /// <summary>
        /// UpdateSupplierRank
        /// </summary>
        /// <param name="supplierId">Supplier ID</param>
        /// <param name="rank">Rank</param>
        /// <returns></returns>
        public bool updateSupplierRank(string supplierId, string rank)
        {
            Supplier s = new Supplier();
            s = (from x in ctx.Supplier
                 where x.SupplierID == supplierId
                 select x).First();
            s.Rank = rank;
            ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// Delete Supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public bool deleteSupplier(string supplierId)
        {
            Supplier s = new Supplier();
            s = (from x in ctx.Supplier
                 where x.SupplierID == supplierId
                 select x).First();
            ctx.Supplier.Remove(s);
            ctx.SaveChanges();
            return true;
        }
        
    }
}
