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
            Model.Delegate dele = new Model.Delegate();
            dele.EmpID = Convert.ToInt32(EmpID);
            dele.DeptID = DeptID;
            dele.StartDate = Convert.ToDateTime(StartDate);
            dele.EndDate = Convert.ToDateTime(EndDate);
            dele.Status = Status;

            ctx.Delegate.Add(dele);
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
        /// <param name="EmpName"></param>
        public bool deleteDelegate(string EmpName)
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
            return true;
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
