using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{

    public class DisbursementController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// GetDisbursementDetail
        /// </summary>
        /// <param name="DisID">Disbursement ID</param>
        /// <returns></returns>
        public DisbursementDetail getDisbursementDetail(string DisID)
        {
            DisbursementDetail result = ctx.DisbursementDetail.Where(x => x.DisID == DisID).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// GetDisbursement
        /// </summary>
        /// <param name="DeptID">Department ID</param>
        /// <param name="CPID">Collection Point ID</param>
        /// <param name="DisID">Disbursement ID</param>
        /// <param name="startdate">Start Date</param>
        /// <param name="enddate">End Date</param>
        /// <returns></returns>
        public List<Disbursement> getDisbursement(string DeptID,string CPID, string DisID, DateTime startdate, DateTime enddate)
        {
            if (DeptID == null)
                DeptID = "";
            if (CPID == null)
                CPID = "";
            if (DisID == null)
                DisID = "";

            //Need to verify the output
            List<Disbursement> result = ctx.Disbursement
                .Where(x => x.DeptID == DeptID)
                .Where(x => x.CPID == CPID)
                .Where(x => x.DisID == DisID)
                .Where(x => x.Date > startdate && x.Date < enddate)
                .ToList();

            return result;
        }

        /// <summary>
        /// CreateDisbursement
        /// </summary>
        /// <param name="disb">Disbursement Object</param>
        /// <returns></returns>
        public bool createDisbursement(Disbursement disb)
        {
            bool result = false;
            
                ctx.Disbursement.Add(disb);
                ctx.SaveChanges();
            return result;
        }

    }
}
