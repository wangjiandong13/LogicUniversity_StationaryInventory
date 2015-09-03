using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DisbursementAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DisbursementAPI.svc or DisbursementAPI.svc.cs at the Solution Explorer and start debugging.
    public class DisbursementAPI : IDisbursementAPI
    {
        public bool createDisbursement(int EmpID)
        {
            BusinessLogic.DisbursementController BL = new BusinessLogic.DisbursementController();
            return BL.createDisbursement(EmpID);
        }

        public List<Disbursement> getDisbursement(string DeptID, string CPID, string DisID, string startdate, string enddate)
        {
            BusinessLogic.DisbursementController BL = new BusinessLogic.DisbursementController();
            return BL.getDisbursement(DeptID, CPID, DisID, startdate, enddate);
        }

        public DisbursementDetail getDisbursementDetail(int DisID)
        {
            BusinessLogic.DisbursementController BL = new BusinessLogic.DisbursementController();
            return BL.getDisbursementDetail(DisID);
        }
    }
}
