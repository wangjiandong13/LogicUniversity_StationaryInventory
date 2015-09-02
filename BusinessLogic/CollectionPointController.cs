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
        /// I think no need 
        /// </summary>
        /// <returns></returns>
        public List<Model.CollectionPoint> getCollectionPoint()
        {
            var cp = from c in ctx.CollectionPoint
                     select c;

            return cp.ToList();
        }

        /// <summary>
        /// get collection point according to Dept ID
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
