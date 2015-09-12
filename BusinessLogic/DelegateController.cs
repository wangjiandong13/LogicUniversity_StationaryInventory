using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DelegateController
    {
        Model.StationeryInventory_Team_05Entities ctx = new Model.StationeryInventory_Team_05Entities();
        /// <summary>
        /// GetDelegate
        /// </summary>
        /// <param name="DeptID">Department ID</param>
        /// <returns></returns>
        public List<Model.Delegate> getDelegate(string DeptID)
        {
            var delegates = from c in ctx.Delegate
                            where c.DeptID == DeptID
                            select c;
            return delegates.ToList();
        }

        /// <summary>
        /// create delegate
        /// </summary>
        /// <param name="dele"></param>
        public bool createDelegate(string EmpID, string DeptID, string StartDate, string EndDate, string Status)
        {
            bool result = true;

            int empID = Convert.ToInt32(EmpID);

            Model.Delegate dele = new Model.Delegate();
            dele.EmpID = empID;
            dele.DeptID = DeptID;
            dele.StartDate = Convert.ToDateTime(StartDate);
            dele.EndDate = Convert.ToDateTime(EndDate);
            dele.Status = Status;
            ctx.Delegate.Add(dele);

            Model.Employee emp = ctx.Employee.Where(x => x.EmpID == empID).FirstOrDefault();
            emp.RoleID = "DD";

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

        /// <summary>
        /// delete Delegate
        /// </summary>
        /// <param name="DelegateSN"></param>
        public bool deleteDelegate(string DelegateSN)
        {
            bool result = true;
           
            int delegateSN = Convert.ToInt32(DelegateSN);

            Model.Delegate dele = ctx.Delegate.Where(x => x.DelegateSN == delegateSN).FirstOrDefault();
            ctx.Delegate.Remove(dele);
            int empid = (int)dele.EmpID;
            Model.Employee emp = (from c in ctx.Employee
                                  where c.EmpID == empid
                                  select c).First();

            emp.RoleID = "EM";

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

        /// <summary>
        /// Edit delegate by emp
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="status"></param>
        public bool editDelegate(string EmpID, string DeptID, string StartDate, string EndDate, string Status)
        {
            bool result = true;
            int empID = Convert.ToInt32(EmpID);
            Model.Delegate d = (from c in ctx.Delegate
                        where c.EmpID == empID
                        select c).First();
            d.StartDate = Convert.ToDateTime(StartDate);
            d.EndDate = Convert.ToDateTime(EndDate);
            d.Status = Status;
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
