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
        public DisbursementDetail getDisbursementDetail(int DisID)
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
        public List<Disbursement> getDisbursement(string DeptID,string CPID, int DisID, DateTime startdate, DateTime enddate)
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
        /// <param name="EmpID">Employee ID(Clerk)</param>
        /// <returns></returns>
        public bool createDisbursement(int EmpID)
        {
            bool result = false;

            string[] deptId = new string[] { "ENGL", "CPSC", "COMM", "REGR", "ZOOL" };

            for (int i = 0; i < deptId.Length; i++)
            {
                List<Requisition> reqList = ctx.Requisition.Where(x => x.StatusID == 3 && x.DeptID == deptId[i]).ToList();

                if (reqList.FirstOrDefault() != null)
                {
                    Department dept = ctx.Department.Where(x => x.DeptID == deptId[i]).FirstOrDefault();

                    Disbursement disb = new Disbursement();
                    disb.Date = DateTime.Now;
                    disb.EmpID = EmpID;
                    disb.DeptID = deptId[i];
                    disb.CPID = dept.CPID;
                    disb.Status = "Pending";

                    ctx.Disbursement.Add(disb);

                    Disbursement lastDisb = ctx.Disbursement.LastOrDefault();
                    int DisID = 0;
                    if(lastDisb != null)
                    {
                        DisID = lastDisb.DisID;
                    }

                    foreach(Requisition req in reqList)
                    {
                        req.DisID = DisID;
                    }
                }
            }

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

    }
}
