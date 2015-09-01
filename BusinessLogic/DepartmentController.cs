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

        /// <summary>
        /// Edit the Department by Dept Head
        /// </summary>
        /// <param name="DepID"></param>
        /// <param name="contact"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="DeptHead"></param>
        /// <param name="Rep"></param>
        /// <returns></returns>
        public bool editDepartment (String DepID, String contact, String phone, String fax, String DeptHead, String Rep )
        {
            Department dept = new Department();
            dept = (from c in ctx.Department
                   where DepID == c.DeptID
                   select c).First();

            dept.Contact = contact;
            dept.Phone = phone;
            dept.Fax = fax;
            dept.DeptHead = DeptHead;
            dept.DeptRep = Rep;

            //ctx.Department.Add(dept);
            ctx.SaveChanges();

            return true;
        }

        
    }
}
