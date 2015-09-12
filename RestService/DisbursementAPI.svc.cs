using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using System.ServiceModel.Web;
using System.Net;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DisbursementAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DisbursementAPI.svc or DisbursementAPI.svc.cs at the Solution Explorer and start debugging.
    public class DisbursementAPI : IDisbursementAPI
    {
        public bool createDisbursement(string EmpID)
        {
            BusinessLogic.DisbursementController BL = new BusinessLogic.DisbursementController();
            if (BL.createDisbursement(EmpID))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotAcceptable;
                return false;
            }
        }

        public List<Disbursement> getDisbursement(string DeptID, string CPID, string DisID, string startdate, string enddate)
        {
            BusinessLogic.DisbursementController BL = new BusinessLogic.DisbursementController();
            return BL.getDisbursement(DeptID, CPID, DisID, startdate, enddate);
        }

        public List<DisbursementDetail> getDisbursementDetail(string DisID)
        {
            BusinessLogic.DisbursementController BL = new BusinessLogic.DisbursementController();
            return BL.getDisbursementDetail(DisID);
        }
    }
}
