using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using System.ServiceModel.Web;
using System.Net;
using System.ServiceModel.Activation;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RequisitionAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RequisitionAPI.svc or RequisitionAPI.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RequisitionAPI : IRequisitionAPI
    {
        public List<Requisition> getRequisitionList(string DisID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisitionList(DisID);
        }

        public bool approve(string ReqId, string HandledBy, string Remark)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            if (BL.approve(ReqId, HandledBy, Remark))
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

        public bool reject(string ReqId, string HandledBy, string Remark)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            if (BL.reject(ReqId, HandledBy, Remark))
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

        public List<Requisition> getRequisition(string StatusID, string ReqID, string EmpID, string DeptID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisition(StatusID, ReqID, EmpID, DeptID);
        }

        public int createRequisition(List<CartItems> itemList)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.createRequisition(itemList);
        }

        public bool setReqPriority(string ReqID, string PriorityID, string Remark)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            if (BL.setReqPriority(ReqID, PriorityID, Remark))
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

        public bool deleteRequisition(string ReqID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            if (BL.deleteRequisition(ReqID))
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

        public List<RequisitionDetail> getRequisitionDetail(string ReqID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisitionDetail(ReqID);
        }

        public List<Requisition> getRequisitionbyId(string RetID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisition(RetID);
        }

        public List<Status> getstatus()
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getstatus();
        }

        public Requisition getRequisitionByReqID(string ReqID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisitionByReqID(ReqID);
        }

        public string getPriorityName(string PriorityID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getPriorityName(PriorityID);
        }

        public List<CartItems> getItemsToReorder(string ReqID, string EmpID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getItemsToReorder(ReqID, EmpID);
        }

        public bool confirmReorder(List<CartItems> ItemList)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.confirmReorder(ItemList);
        }

        public List<Requisition> getRequisitionApprovalList(string DeptID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisitionApprovalList(DeptID);
        }
    }
}
