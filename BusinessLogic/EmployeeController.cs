using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeeController
    {
        Model.StationeryInventory_Team_05Entities ctx = new Model.StationeryInventory_Team_05Entities();
        /// <summary>
        /// GetEmployeebyRole
        /// </summary>
        /// <param name="role">Role ID</param>
        /// <returns></returns>
        public List<Model.Employee> getemployeebyrole(string role)
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
        public List<Model.Employee> getemployeebyDeptName(string DeptName)
        {
            var employees = from c in ctx.Employee
                            where c.DeptID == DeptName
                            select c;
            return employees.ToList();
        }
    }
}
