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
            DisbursementDetail result = ctx.DisbursementDetail.Where(x => x.DisID == Convert.ToInt32(DisID)).FirstOrDefault();
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
        public List<Disbursement> getDisbursement(string DeptID, string CPID, string DisID, string startdate, string enddate)
        {
            //start with all the records
            var query = from disb in ctx.Disbursement select disb;

            //filter the result set based on user inputs
            if (!string.IsNullOrEmpty(DeptID))
            {
                query = query.Where(x => x.DeptID.Contains(DeptID));
            }
            if (!string.IsNullOrEmpty(CPID))
            {
                query = query.Where(x => x.CPID.ToString().Contains(CPID));
            }
            if (!string.IsNullOrEmpty(DisID))
            {
                query = query.Where(x => x.DisID.ToString().Contains(DisID));
            }
            if (!string.IsNullOrEmpty(startdate))
            {
                DateTime sd = Convert.ToDateTime(startdate).Date;
                query = query.Where(x => x.Date >= sd);
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                DateTime ed = Convert.ToDateTime(enddate).Date;
                query = query.Where(x => x.Date <= ed);
            }

            //run the query on database and grab the results
            return query.ToList();
        }

        /// <summary>
        /// CreateDisbursement
        /// </summary>
        /// <param name="EmpID">Employee ID(Clerk)</param>
        /// <returns></returns>
        public bool createDisbursement(string EmpID)
        {
            bool result = true;

            string[] deptId = new string[] { "ENGL", "CPSC", "COMM", "REGR", "ZOOL" };

            for (int i = 0; i < deptId.Length; i++)
            {
                List<Requisition> reqList = ctx.Requisition.Where(x => x.StatusID == 3 && x.DeptID == deptId[i]).ToList();

                if (reqList.FirstOrDefault() != null)
                {
                    Department dept = ctx.Department.Where(x => x.DeptID == deptId[i]).FirstOrDefault();

                    Disbursement disb = new Disbursement();
                    disb.Date = DateTime.Now;
                    disb.EmpID = Convert.ToInt32(EmpID);
                    disb.DeptID = deptId[i];
                    disb.CPID = dept.CPID;
                    disb.Status = "PENDING";

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
