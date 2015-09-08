using Model;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RetrievalAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RetrievalAPI.svc or RetrievalAPI.svc.cs at the Solution Explorer and start debugging.
    public class RetrievalAPI : IRetrievalAPI
    {
        public int createRetrieval(List<ProcessRetrieval> processRetList)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            return BL.createRetrieval(processRetList);
        }

        public List<Retrieval> getRetrieval(string EmpID, string Status, string RetID)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            return BL.getRetrieval(EmpID, Status, RetID);
        }

        public bool submit(List<RetrievalDetail> retDetailList)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            if (BL.submit(retDetailList))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                return false;
            }
        }

        public bool save(List<RetrievalDetail> retDetailList)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            if (BL.save(retDetailList))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                return false;
            }
        }

        public List<ProcessRetSuccess> getRetrievalDetail(string RetID)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            return BL.getRetrievalDetail(RetID);
        }

        public List<ReqAllocation> getReqAllocation(string RetID)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            return BL.getReqAllocation(RetID);
        }

        public bool confirmAllocation(List<RequisitionDetail> reqDetailList)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            if (BL.confirmAllocation(reqDetailList))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                return false;
            }
        }


        public List<ReqAllocation> getRetByDept(string RetID)
        {
            BusinessLogic.RetrievalController BL = new BusinessLogic.RetrievalController();
            return BL.getRetByDept(RetID);
        }

    }
}
