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

        public List<Department> getAllDepartment()
        {
            var departments = from c in ctx.Department
                              select c;
            return departments.ToList();
        }
        public Department getDeptByID(string DepID)
        {
            Department dept = new Department();
            dept = (from c in ctx.Department
                       where c.DeptID == DepID
                       select c).First();
            return dept;
        }

    }
}
