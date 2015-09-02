using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Delegate
    {
        Model.StationeryInventory_Team_05Entities ctx = new Model.StationeryInventory_Team_05Entities();

        /// <summary>
        /// get delegate by DeptID
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public List<Model.Delegate> getDelegatebyID(string DeptID)
        {
            var delegates = from c in ctx.Delegate
                            where c.DeptID == DeptID
                            select c;
            return delegates.ToList();
        }

        /// <summary>
        /// get delegate
        /// </summary>
        /// <returns></returns>
        public List<Model.Delegate> getDelegate()
        {
            var delegates = from c in ctx.Delegate
                            select c;
            return delegates.ToList();
        }

        /// <summary>
        /// create delegate
        /// </summary>
        /// <param name="dele"></param>
        public bool createDelegate(Model.Delegate dele)
        {
            ctx.Delegate.Add(dele);
            ctx.SaveChanges();
            return true;
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
        public bool editDelegate(string empID, DateTime startdate, DateTime enddate, String status)
        {
            var dele = (from c in ctx.Delegate
                       where c.EmpID == empID
                       select c).First();
            dele.StartDate = startdate;
            dele.EndDate = enddate;
            dele.Status = status;
            ctx.SaveChanges();
            return true;
        }

    }
}
