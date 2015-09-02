using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    class RetrievalController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// CreateRetrieval
        /// </summary>
        /// <param name="processRetList">ProcessRetrieval List (EmpID, ReqID)</param>
        /// <returns></returns>
        public int createRetrieval(List<ProcessRetrieval> processRetList)
        {
            int result = 0;
            
            //create and add new retrieval 
            Retrieval ret = new Retrieval();
            ret.Date = DateTime.Now;
            ret.EmpID = processRetList.First().EmpID;
            ret.Status = "Pending";
            ctx.Retrieval.Add(ret);

            //obtain retID of newly added retrieval
            int RetID = ctx.Retrieval.Last().RetID;

            //hashmap-like to store itemID and collated qty
            Dictionary<string, int> itemQty = new Dictionary<string, int>();

            foreach (ProcessRetrieval processRet in processRetList)
            {
                //update RetID of requisition
                ctx.Requisition.Where(x => x.ReqID == processRet.ReqID).First().RetID = RetID;

                //obtain requisition detail list 
                List<RequisitionDetail> reqDetailList = ctx.RequisitionDetail.Where(x => x.ReqID == processRet.ReqID).ToList();
                
                foreach (RequisitionDetail reqDetail in reqDetailList)
                {
                    //if itemQty does not contain the item, add item to itemQty
                    if (!itemQty.ContainsKey(reqDetail.ItemID))
                    {
                        itemQty.Add(reqDetail.ItemID, (int)reqDetail.RequestQty);
                    }
                    //else if itemQty contains item, add the qty to existing qty
                    else
                    {
                        itemQty["reqDetail.ItemID"] += (int) reqDetail.RequestQty;
                    }
                }
            }

            //extract all keys and values in itemQty
            string[] itemQtyKeys = itemQty.Keys.ToArray();
            int[] itemQtyValues = itemQty.Values.ToArray();

            for (int i = 0; i < itemQty.Count; i++)
            {
                //create and add new retrieval detail
                RetrievalDetail retrievalDetail = new RetrievalDetail();
                retrievalDetail.RetID = RetID;
                retrievalDetail.ItemID = itemQtyKeys[i];
                retrievalDetail.RequestQty = itemQtyValues[i];
                ctx.RetrievalDetail.Add(retrievalDetail);
            }

            int count = ctx.SaveChanges();

            if (count > 0)
                result = RetID;

            return result;
        }

        /// <summary>
        /// GetList
        /// </summary>
        /// <param name="EmpID">Store Clerk EmpID</param>
        /// <param name="Status">Status (Pending / Retrieved)</param>
        /// <param name="RetID">Retrieval ID</param>
        /// <returns></returns>
        public List<Retrieval> getRetrieval(int EmpID, string Status, int RetID)
        {
            List<Retrieval> retList = ctx.Retrieval
                .Where(x => x.EmpID == EmpID)
                .Where(x => x.Status == Status)
                .Where(x => x.RetID == RetID)
                .ToList();

            return retList;
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="retDetailList">RetrievalDetail List (RetID, ItemID, ActualQty)</param>
        /// <returns></returns>
        public bool submit(List<RetrievalDetail> retDetailList)
        {
            bool result = false;

            //update actual quantity of retrieval detail
            foreach (RetrievalDetail retDetail in retDetailList)
            {
                RetrievalDetail retDetailSearch = ctx.RetrievalDetail.Where(x => x.RetID == retDetail.RetID && x.ItemID == retDetail.ItemID).FirstOrDefault();
                retDetailSearch.ActualQty = retDetail.ActualQty;
            }

            //update status of retrieval to "Retrieved"
            Retrieval ret = ctx.Retrieval.Where(x => x.RetID == retDetailList.First().RetID).FirstOrDefault();
            ret.Status = "Retrieved";

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="retDetailList">RetrievalDetail List (RetID, ItemID, ActualQty)</param>
        /// <returns></returns>
        public bool save(List<RetrievalDetail> retDetailList)
        {
            bool result = false;

            //update actual quantity of retrieval detail
            foreach (RetrievalDetail retDetail in retDetailList)
            {
                RetrievalDetail retDetailSearch = ctx.RetrievalDetail.Where(x => x.RetID == retDetail.RetID && x.ItemID == retDetail.ItemID).FirstOrDefault();
                retDetailSearch.ActualQty = retDetail.ActualQty;
            }
            
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// GetRetrievalDetail
        /// </summary>
        /// <param name="RetID">Retrieval ID</param>
        /// <returns></returns>
        public List<ProcessRetSuccess> getRetrievalDetail(int RetID)
        {
            Retrieval ret = ctx.Retrieval.Where(x => x.RetID == RetID).FirstOrDefault();
            List<RetrievalDetail> retDetailList = ctx.RetrievalDetail.Where(x => x.RetID == RetID).ToList();

            List<ProcessRetSuccess> retSuccessList = new List<ProcessRetSuccess>();

            foreach(RetrievalDetail retDetail in retDetailList)
            {
                Item i = ctx.Item.Where(x => x.ItemID == retDetail.ItemID).FirstOrDefault();
                ProcessRetSuccess retSuccess = new ProcessRetSuccess();
                retSuccess.Date = (DateTime) ret.Date;
                retSuccess.Bin = i.Bin;
                retSuccess.ItemID = i.ItemID;
                retSuccess.ItemName = i.ItemName;
                retSuccess.TotalQty = (int) retDetail.RequestQty;
                retSuccess.ActualQty = (int) retDetail.ActualQty;

                retSuccessList.Add(retSuccess);
            }

            return retSuccessList;
        }

        /// <summary>
        /// GetReqAllocation
        /// </summary>
        /// <param name="RetID">Requisition ID</param>
        /// <returns></returns>
        public List<ReqAllocation> getReqAllocation(int RetID)
        {
            List<Requisition> reqList = ctx.Requisition.Where(x => x.RetID == RetID).ToList();

            List<ReqAllocation> reqAllocationList = new List<ReqAllocation>();

            foreach(Requisition req in reqList)
            {
                List<RequisitionDetail> reqDetailList = ctx.RequisitionDetail.Where(x => x.ReqID == req.ReqID).ToList();

                foreach (RequisitionDetail reqDetail in reqDetailList)
                {
                    ReqAllocation reqAllocation = new ReqAllocation();
                    reqAllocation.ItemID = reqDetail.ItemID;
                    reqAllocation.ReqID = req.ReqID;
                    reqAllocation.Dept = req.DeptID;
                    if(req.PriorityID == 1)
                        reqAllocation.Priority = "High";
                    else
                        reqAllocation.Priority = "Low";
                    reqAllocation.RequestQty = (int) reqDetail.RequestQty;
                    reqAllocation.IssueQty = (int)reqDetail.IssueQty;

                    reqAllocationList.Add(reqAllocation);
                }
            }
            return reqAllocationList;
        }


        /// <summary>
        /// confirmAllocation
        /// </summary>
        /// <param name="reqDetailList">RequisitionDetail List (ReqID, ItemID, IssueQty)</param>
        /// <returns></returns>
        public bool confirmAllocation(List<RequisitionDetail> reqDetailList)
        {
            bool result = false;

            foreach(RequisitionDetail reqDetail in reqDetailList)
            {
                RequisitionDetail reqDetailSearch = ctx.RequisitionDetail
                    .Where(x => x.ReqID == reqDetail.ReqID && x.ItemID == reqDetail.ItemID)
                    .FirstOrDefault();

                reqDetailSearch.IssueQty = reqDetail.IssueQty;
            }

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

    }
}
