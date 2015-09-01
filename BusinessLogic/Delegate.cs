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
    }
}
