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
        /// <param name="CPID">Collection Point ID</param>
        /// <returns>Collection Point List</returns>
        public List<Model.CollectionPoint> getCollectionPoint(string CPID)
        {
            int cpid = Convert.ToInt32(CPID);
            var cp = from c in ctx.CollectionPoint
                     where c.CPID == cpid
                     select c;

            return cp.ToList();
        }

        /// <summary>
        /// Change collection point according to Dept
        /// </summary>
        /// <param name="DeptID">Department ID</param>
        /// <param name="CPID">Collection Point ID</param>
        /// <returns>true if the </returns>
        public bool updateCollectionPoint(string DeptID, string CPID)
        {
            Model.Department dept = (from c in ctx.Department
                    where c.DeptID == DeptID
                    select c).First();
            dept.CPID = Convert.ToInt32(CPID);
            ctx.SaveChanges();
            return true;
        }
    }
}
