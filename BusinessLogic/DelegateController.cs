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
        public void createDelegate(Model.Delegate dele)
        {
            ctx.Delegate.Add(dele);
            ctx.SaveChanges();
        }

        /// <summary>
        /// delete Delegate
        /// </summary>
        /// <param name="EmpName"></param>
        public void deleteDelegate(string EmpName)
        {
            Model.Employee emp = new Model.Employee();
            Model.Delegate dele = new Model.Delegate();

            emp = (from c in ctx.Employee
                   where c.EmpName == EmpName
                   select c).First();

            dele = (from c in ctx.Delegate
                    where c.EmpID == emp.EmpID
                    select c).First();
            ctx.Delegate.Remove(dele);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Edit delegate by emp
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <param name="status"></param>
        public void editDelegate(string empID, DateTime startdate, DateTime enddate, String status)
        {
            var dele = (from c in ctx.Delegate
                        where c.EmpID == empID
                        select c).First();
            dele.StartDate = startdate;
            dele.EndDate = enddate;
            dele.Status = status;
            ctx.SaveChanges();
        }

    }
}
