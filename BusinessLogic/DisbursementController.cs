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
        public List<DisbursementDetail> getDisbursementDetail(string DisID)
        {
            int disID = Convert.ToInt32(DisID);
            List<DisbursementDetail> result = ctx.DisbursementDetail.Where(x => x.DisID == disID).ToList();
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
            if (DeptID == "null")
                DeptID = null;
            if (CPID == "null")
                CPID = null;
            if (DisID == "null")
                DisID = null;
            if (startdate == "null")
                startdate = null;
            if (enddate == "null")
                enddate = null;

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
                string deptID = deptId[i];
                List<Requisition> reqList = ctx.Requisition.Where(x => x.StatusID == 3 && x.DeptID == deptID).ToList();

                if (reqList.FirstOrDefault() != null)
                {
                    Department dept = ctx.Department.Where(x => x.DeptID == deptID).FirstOrDefault();
                    Employee deptRep = ctx.Employee.Where(x => x.DeptID == deptID && x.RoleID == "DR").FirstOrDefault();


                    Disbursement disb = new Disbursement();
                    disb.Date = DateTime.Now;
                    disb.EmpID = Convert.ToInt32(EmpID);
                    disb.DeptID = deptID;
                    disb.CPID = dept.CPID;
                    disb.ReceivedBy = deptRep.EmpID;
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

            if (result == true)
            {
                if(EmpID == null)
                {
                    EmpID = "0";
                }
                List<Requisition> reqList = ctx.Requisition.Where(x => x.StatusID == 3).ToList();
                foreach (Requisition req in reqList)
                {
                    //send notification to req holders:
                    NotificationController nt = new NotificationController();
                    nt.sendNotification(5, Convert.ToInt32(EmpID), Convert.ToString(req.ReqID));
                }
                //send notification about collection one day after.
                NotificationController nt2 = new NotificationController();
                DateTime d = DateTime.Now;
                nt2.sendNotification(11, Convert.ToInt32(EmpID), d.AddDays(1).ToString("dd'/'MM'/'yyyy"));
            }

            return result;
        }


        public bool completeDisbursement(string DisID)
        {
            bool result = true;

            //update disbursement status to "Disbursed"
            int disID = Convert.ToInt32(DisID);
            Disbursement disb = ctx.Disbursement.Where(x => x.DisID == disID).FirstOrDefault();
            disb.Status = "DISBURSED";

            //update requisition status to "Collected" (statusID = 4)
            List<Requisition> reqList = ctx.Requisition.Where(x => x.DisID == disID).ToList();
            foreach(Requisition req in reqList)
            {
                req.StatusID = 4;
            }

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            //send notification to req holders:
            if (result == true)
            {
                List<Requisition> requisitions = ctx.Requisition.Where(x => x.StatusID == 4 && x.DisID == disID).ToList();
                foreach (Requisition req in requisitions)
                {
                    NotificationController nt = new NotificationController();
                    nt.sendNotification(6, 0, Convert.ToString(req.ReqID));
                }
            }

            return result;

        }
    }
}
