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
            dept.CPID = d.CPID;
            dept.DeptName = d.DeptName;
            dept.DeptHead = d.DeptHead;
            dept.DeptRep = d.DeptRep;

            Employee deptRepOld = ctx.Employee.Where(x => x.RoleID == "DR").FirstOrDefault();
            if(deptRepOld.EmpID != d.DeptRep)
            {
                deptRepOld.RoleID = "EM";
                Employee deptRepNew = ctx.Employee.Where(x => x.EmpID == d.DeptRep).FirstOrDefault();
                deptRepNew.RoleID = "DR";
            }

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            //send notification to alert changes:
            if (result == true)
            {
                Department dpt = ctx.Department.Where(x => x.DeptID == d.DeptID).FirstOrDefault();
                if(d.DeptRep != dpt.DeptRep)
                {
                    NotificationController nt = new NotificationController();
                    nt.sendNotification(12, Convert.ToInt32(dpt.DeptRep), dpt.DeptID);
                }
                if (d.CollectionPoint != dpt.CollectionPoint)
                {
                    NotificationController nt = new NotificationController();
                    nt.sendNotification(13, Convert.ToInt32(dpt.DeptRep), dpt.DeptID);
                }
            }

            return result;
        }

    }
}
