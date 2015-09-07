using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class RequisitionController
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
        /// <param name="HandledBy">Handled By (Dept Head EmpID)</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool approve(int ReqId, int HandledBy, string Remark)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqId).FirstOrDefault();
            req.StatusID = 2;
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
        /// <param name="HandledBy">Handled By (Dept Head EmpID)</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool reject(int ReqId, int HandledBy, string Remark)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqId).FirstOrDefault();
            req.StatusID = 5;
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
        public List<Requisition> getRequisition(string StatusID, string ReqID, string EmpID)
        {
            //start with all the records
            var query = from req in ctx.Requisition select req;

            //filter the result set based on user inputs
            if (!string.IsNullOrEmpty(StatusID))
            {
                query = query.Where(x => x.StatusID.ToString().Contains(StatusID));
            }
            if (!string.IsNullOrEmpty(ReqID))
            {
                query = query.Where(x => x.ReqID.ToString().Contains(ReqID));
            }
            if (!string.IsNullOrEmpty(EmpID))
            {
                query = query.Where(x => x.EmpID.ToString().Contains(EmpID));
            }

            //run the query on database and grab the results
            return query.ToList();
        }

        /// <summary>
        /// CreateRequisition
        /// </summary>
        /// <param name="itemList">CartItems List (EmpID, ItemID, Qty)</param>
        /// <returns></returns>
        public int createRequisition(List<CartItems> itemList)
        {
            int result = 0;
            int ReqID = 0;

            if (itemList.FirstOrDefault() != null)
            {
                //create and add new requisition
                Requisition req = new Requisition();
                req.EmpID = itemList.First().EmpID;
                req.DeptID = ctx.Employee.Where(x => x.EmpID == itemList.First().EmpID).First().DeptID;
                req.Date = DateTime.Now;
                req.StatusID = 1;
                ctx.Requisition.Add(req);

                //obtain the ReqID of the newly added requisition
                ReqID = ctx.Requisition.Last().ReqID;

                //create and add new requisition details
                foreach(CartItems item in itemList)
                {
                    RequisitionDetail reqDetail = new RequisitionDetail();
                    reqDetail.ReqID = ReqID;
                    reqDetail.ItemID = item.ItemID;
                    reqDetail.RequestQty = item.Qty;
                    ctx.RequisitionDetail.Add(reqDetail);
                }
            }
            
            int count = ctx.SaveChanges();

            if (count > 0)
                result = ReqID;
            return result;
        }

        /// <summary>
        /// SetReqPriority
        /// </summary>
        /// <param name="ReqID">Requisition ID</param>
        /// <param name="PriorityID">Priority ID</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool setReqPriority(int ReqID, int PriorityID, string Remark)
        {
            bool result = false;

            Requisition req = ctx.Requisition.Where(x => x.ReqID == ReqID).FirstOrDefault();
            if (req != null)
            {
                req.PriorityID = PriorityID;
                req.Remark = Remark;
            }

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
        /// GetRequisition
        /// </summary>
        /// <param name="RetID">Retrieval ID</param>
        /// <returns></returns>
        public List<Requisition> getRequisition(int RetID)
        {
            List<Requisition> reqList = ctx.Requisition.Where(x => x.RetID == RetID).ToList();
            return reqList;
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
