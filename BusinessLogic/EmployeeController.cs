using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();
        /// <summary>
        /// GetEmployeebyRole
        /// </summary>
        /// <param name="role">Role ID</param>
        /// <returns></returns>
        public List<Employee> getemployeebyrole(string role)
        {
            var employees = from c in ctx.Employee
                            where c.RoleID == role
                            select c;
            return employees.ToList();
        }

        /// <summary>
        /// GetEmployeebyDeptName
        /// </summary>
        /// <param name="DeptName">Department name</param>
        /// <returns></returns>
        public List<Employee> getemployeebyDeptID(string DeptID)
        {
            var employees = from c in ctx.Employee
                            where c.DeptID == DeptID
                            select c;
            return employees.ToList();
        }

        public Employee login(Employee e)
        {
            var employees = from c in ctx.Employee
                            where c.EmpID==e.EmpID
                            select c;
            Employee re = employees.FirstOrDefault();
            if (re != null)
            {
                if (re.Password == e.Password)
                {
                    return re;
                }
                return null;
            }
            return null;
        }
    }
}
