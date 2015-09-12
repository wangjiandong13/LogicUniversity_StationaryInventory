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
        public List<Requisition> getRequisitionList(string DisID)
        {
            int disID = Convert.ToInt32(DisID);
            List<Requisition> result = ctx.Requisition.Where(x => x.DisID == disID).ToList();

            return result;
        }

        /// <summary>
        /// Approve
        /// </summary>
        /// <param name="ReqId">Requisition ID</param>
        /// <param name="HandledBy">Handled By (Dept Head EmpID)</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool approve(string ReqId, string HandledBy, string Remark)
        {
            bool result = true;

            int reqID = Convert.ToInt32(ReqId);
            Requisition req = ctx.Requisition.Where(x => x.ReqID == reqID).FirstOrDefault();
            req.StatusID = 2;
            req.HandledBy = Convert.ToInt32(HandledBy);
            req.Remark = Remark;

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
                //send notification:
                NotificationController nt = new NotificationController();
                nt.sendNotification(2, Convert.ToInt32(HandledBy), ReqId);
            }

            return result;
        }

        /// <summary>
        /// Reject
        /// </summary>
        /// <param name="ReqId">Requisition ID</param>
        /// <param name="HandledBy">Handled By (Dept Head EmpID)</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool reject(string ReqId, string HandledBy, string Remark)
        {
            bool result = true;

            int reqID = Convert.ToInt32(ReqId);
            Requisition req = ctx.Requisition.Where(x => x.ReqID == reqID).FirstOrDefault();
            req.StatusID = 5;
            req.HandledBy = Convert.ToInt32(HandledBy);
            req.Remark = Remark;

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            if(result == true)
            {
                //send notification:
                NotificationController nt = new NotificationController();
                nt.sendNotification(3, Convert.ToInt32(HandledBy), ReqId);
            }

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
            if (StatusID == "null")
                StatusID = null;
            if (ReqID == "null")
                ReqID = null;
            if (EmpID == "null")
                EmpID = null;

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
                int empid = itemList.First().EmpID;
                req.DeptID = ctx.Employee.Where(x => x.EmpID == empid).First().DeptID;
                req.Date = DateTime.Now;
                req.StatusID = 1;
                ctx.Requisition.Add(req);

                //obtain the ReqID of the newly added requisition
                Requisition reqLast = ctx.Requisition.Where(x => x.EmpID == empid).ToList().Last();
                ReqID = reqLast.ReqID;

                //create and add new requisition details
                foreach (CartItems item in itemList)
                {
                    RequisitionDetail reqDetail = new RequisitionDetail();
                    reqDetail.ReqID = ReqID;
                    reqDetail.ItemID = item.ItemID;
                    reqDetail.RequestQty = item.Qty;
                    ctx.RequisitionDetail.Add(reqDetail);
                }

                //delete items from request cart
                foreach(CartItems item in itemList)
                {
                    CartItems cartItem = ctx.CartItems.Where(x => x.EmpID == item.EmpID && x.ItemID == item.ItemID).FirstOrDefault();
                    ctx.CartItems.Remove(cartItem);
                }
                
            }

            int count = ctx.SaveChanges();

            if (count > 0)
                result = ReqID;

            if (result == ReqID)
            {
                //send notification:
                NotificationController nt = new NotificationController();
                nt.sendNotification(1, itemList.First().EmpID, Convert.ToString(ReqID));
            }

            return result;
        }

        /// <summary>
        /// SetReqPriority
        /// </summary>
        /// <param name="ReqID">Requisition ID</param>
        /// <param name="PriorityID">Priority ID</param>
        /// <param name="Remark">Remark</param>
        /// <returns></returns>
        public bool setReqPriority(string ReqID, string PriorityID, string Remark)
        {
            bool result = true;

            int reqID = Convert.ToInt32(ReqID);
            Requisition req = ctx.Requisition.Where(x => x.ReqID == reqID).FirstOrDefault();
            if (req != null)
            {
                req.PriorityID = Convert.ToInt32(PriorityID);
                req.Remark = Remark;
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

        /// <summary>
        /// DeleteRequisition
        /// </summary>
        /// <param name="ReqID">Requisition ID</param>
        /// <returns></returns>
        public bool deleteRequisition(string ReqID)
        {
            bool result = true;

            int reqID = Convert.ToInt32(ReqID);
            Requisition req = ctx.Requisition.Where(x => x.ReqID == reqID).FirstOrDefault();
            //set status to "Cancelled"
            req.StatusID = 6;

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

        /// <summary>
        /// GetRequisitionDetail
        /// </summary>
        /// <param name="ReqId">Requisition ID</param>
        /// <returns></returns>
        public List<RequisitionDetail> getRequisitionDetail(string ReqId)
        {
            int reqID = Convert.ToInt32(ReqId);
            List<RequisitionDetail> result = ctx.RequisitionDetail.Where(x => x.ReqID == reqID).ToList();
            return result;
        }

        /// <summary>
        /// GetRequisition
        /// </summary>
        /// <param name="RetID">Retrieval ID</param>
        /// <returns></returns>
        public List<Requisition> getRequisition(string RetID)
        {
            int retID = Convert.ToInt32(RetID);
            List<Requisition> reqList = ctx.Requisition.Where(x => x.RetID == retID).ToList();
            return reqList;
        }

        /// <summary>
        /// Getstatus
        /// </summary>
        /// <returns></returns>
        public List<Status> getstatus()
        {
            return ctx.Status.ToList();
        }

    }
}
