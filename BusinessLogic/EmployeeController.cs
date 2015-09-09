using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        /// GetEmployeebyRole
        /// </summary>
        /// <param name="EmpID">Employee ID</param>
        /// <returns></returns>
        public Employee getemployeebyId(string EmpID)
        {
            int empID = Convert.ToInt32(EmpID);
            Employee employee = ctx.Employee.Where(x => x.EmpID == empID).FirstOrDefault();
            return employee;
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

        public bool updateEmployeeRole(string EmpID, string RoleID)
        {
            bool result = true;

            int empID = Convert.ToInt32(EmpID);
            Employee employee = ctx.Employee.Where(x => x.EmpID == empID).FirstOrDefault();
            employee.RoleID = RoleID;

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

        public Employee login(Employee e)
        {
            var employees = from c in ctx.Employee
                            where c.EmpID==e.EmpID
                            select c;
            Employee re = employees.FirstOrDefault();
            
            if (re != null)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string source = e.Password + re.EmpID;
                    string hash = GetMd5Hash(md5Hash, source);

                    if (hash==re.Password)
                    {
                        return re;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

    }
}
