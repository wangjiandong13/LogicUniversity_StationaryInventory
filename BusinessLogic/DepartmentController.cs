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
        public List<Department> getAllDept()
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

        /// <summary>
        /// update department information
        /// </summary>
        /// <param name="d"></param>
        public bool updateDept(Department d)
        {
            bool result = true;

            var dept = (from c in ctx.Department
                   where d.DeptID == c.DeptID
                   select c).First();

            dept.Contact = d.Contact;
            dept.Phone = d.Phone;
            dept.Fax = d.Fax;
            dept.DeptHead = d.DeptHead;
            dept.DeptRep = d.DeptRep;
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
