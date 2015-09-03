using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CollectionPointController
    {
        Model.StationeryInventory_Team_05Entities ctx = new Model.StationeryInventory_Team_05Entities();

        /// <summary>
        /// get all collection points
        /// </summary>
        /// <returns>List of Collection Point</returns>
        public List<Model.CollectionPoint> getCollectionPoint()
        {
            var cp = from c in ctx.CollectionPoint
                     select c;

            return cp.ToList();
        }

        /// <summary>
        /// get collection point according to Dept ID (one Dept may have one or more collection point)
        /// </summary>
        /// <param name="d">Department Object</param>
        /// <returns>Collection Point List</returns>
        public List<Model.CollectionPoint> getCollectionPoint(Model.Department d)
        {
            var cp = from c in ctx.CollectionPoint
                     where c.CPID == d.CPID
                     select c;

            return cp.ToList();
        }

        /// <summary>
        /// Change collection point according to Dept
        /// </summary>
        /// <param name="d"></param>
        /// <returns>true if the </returns>
        public bool updateCollectionPoint(Model.Department d)
        {
            Model.Department dept = new Model.Department();

            dept = (from c in ctx.Department
                    where c.DeptID == d.DeptID
                    select c).First();
            dept.CPID = d.CPID;
            ctx.SaveChanges();
            return true;

        }
    }
}
