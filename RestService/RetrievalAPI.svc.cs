using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RetrievalAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RetrievalAPI.svc or RetrievalAPI.svc.cs at the Solution Explorer and start debugging.
    public class RetrievalAPI : IRetrievalAPI
    {

        public bool approve(string ReqId, string HandledBy, string Remark)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.approve(ReqId, HandledBy, Remark);
        }

        public int createRequisition(List<CartItems> itemList)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.createRequisition(itemList);
        }

        public bool deleteRequisition(string ReqID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.deleteRequisition(ReqID);
        }

        public List<Requisition> getRequisition(string RetID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisition(RetID);
        }

        public List<Requisition> getRequisition(string StatusID, string ReqID, string EmpID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisition(StatusID, ReqID, EmpID);
        }

        public List<RequisitionDetail> getRequisitionDetail(string ReqID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisitionDetail(ReqID);
        }

        public List<Requisition> getRequisitionList(string DisID)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.getRequisitionList(DisID);
        }

        public bool reject(string ReqId, string HandledBy, string Remark)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.reject(ReqId, HandledBy, Remark);
        }

        public bool setReqPriority(string ReqID, string PriorityID, string Remark)
        {
            BusinessLogic.RequisitionController BL = new BusinessLogic.RequisitionController();
            return BL.setReqPriority(ReqID, PriorityID, Remark);
        }
    }
}
