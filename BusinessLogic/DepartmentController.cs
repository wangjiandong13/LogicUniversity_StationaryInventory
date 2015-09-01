using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class DepartmentController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();
        /// <summary>
        /// Get All Department
        /// </summary>
        /// <returns></returns>
        public List<Department> getAllDepartment()
        {
            var departments = from c in ctx.Department
                              select c;
            return departments.ToList();
        }

        /// <summary>
        /// Get one Department
        /// </summary>
        /// <param name="DepID"></param>
        /// <returns></returns>
        public Department getDeptByID(string DepID)
        {
            Department dept = new Department();
            dept = (from c in ctx.Department
                       where c.DeptID == DepID
                       select c).First();
            return dept;
        }

        public Department editDepartment (String DepID, String contact, int phone, int fax, String DeptHead, String Rep )
        {
            //Supplier s = new Supplier();
            //s.SupplierID = supplierId;
            //s.SupplierName = supplierName;
            //s.Contact = contact;
            //s.RegNo = regno;
            //s.Phone = phone;
            //s.Address = address;
            //s.Fax = fax;
            //s.Rank = "4";

            //ctx.Supplier.Add(s);
            //ctx.SaveChanges();

            //return true;

            Department dept = new Department();
            return dept;
         

        }
        
    }
}
