using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    class RequisitionController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// GetRequisitionList
        /// </summary>
        /// <param name="DisID">Disbursement ID</param>
        /// <returns></returns>
        public List<Requisition> getRequisitionList(int DisID)
        {
            List<Requisition> result = ctx.Requisition.Where(x => x.DisID == DisID).ToList();

            return result;
        }

        /// <summary>
        /// Approve
        /// </summary>
        /// <param name="ReqId">Requisition ID</param>
        /// <param name="HandledBy">Handled By</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool approve(int ReqId, string HandledBy, string Remark)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqId).FirstOrDefault();
            req.HandledBy = HandledBy;
            req.Remark = Remark;

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// Reject
        /// </summary>
        /// <param name="ReqId">Requisition ID</param>
        /// <param name="HandledBy">Handled By</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool reject(int ReqId, string HandledBy, string Remark)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqId).FirstOrDefault();
            req.HandledBy = HandledBy;
            req.Remark = Remark;

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// GetRequisition
        /// </summary>
        /// <param name="StatusID">Status ID</param>
        /// <param name="ReqID">Requisition ID</param>
        /// <param name="EmpID">Employee ID</param>
        /// <returns></returns>
        public List<Requisition> getRequisition(int StatusID, int ReqID, string EmpID)
        {
            List<Requisition> result = ctx.Requisition
                .Where(x => x.StatusID == StatusID)
                .Where(x => x.ReqID == ReqID)
                .Where(x => x.EmpID == EmpID)
                .ToList();

            return result;
        }

        /// <summary>
        /// CreateRequisition
        /// </summary>
        /// <param name="req">Requisition Object</param>
        /// <returns></returns>
        public bool createRequisition(Requisition req)
        {
            bool result = false;

            ctx.Requisition.Add(req);
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// CreateRequisitionDetail
        /// </summary>
        /// <param name="reqDetail">Requisition Detail</param>
        /// <returns></returns>
        public bool createRequisitionDetail(RequisitionDetail reqDetail)
        {
            bool result = false;

            ctx.RequisitionDetail.Add(reqDetail);
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// DeleteRequisition
        /// </summary>
        /// <param name="ReqID">Requisition ID</param>
        /// <returns></returns>
        public bool deleteRequisition(int ReqID)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqID).FirstOrDefault();
            //set status to "Cancelled"
            req.StatusID = 6;
            
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// GetRequisitionDetail
        /// </summary>
        /// <param name="ReqId">Requisition ID</param>
        /// <returns></returns>
        public List<RequisitionDetail> getRequisitionDetail(int ReqId)
        {
            List<RequisitionDetail> result = ctx.RequisitionDetail.Where(x => x.ReqID == ReqId).ToList();

            return result;
        }

        /// <summary>
        /// GetReqDetailByRetrieval
        /// </summary>
        /// <param name="RetID">Requisition ID</param>
        /// <returns></returns>
        //public List<RequisitionDetail> getReqDetailByRetrieval(string RetID)
        //{
        //    List<Requisition> reqList = ctx.Requisition.Where(x => x.RetID == RetID).ToList();

        //    List<RequisitionDetail> result = new List<RequisitionDetail>();
        //    foreach (Requisition req in reqList)
        //    {
        //        RequisitionDetail reqDetail = ctx.RequisitionDetail.Where(x => x.ReqID == req.ReqID).FirstOrDefault();
        //        result.Add(reqDetail);
        //    }

        //    //how to collate the items and respective quantity

        //    return result;
        //}

    }
}
