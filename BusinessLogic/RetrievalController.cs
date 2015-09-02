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
        public List<Retrieval> getList(int EmpID, string Status, int RetID)
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
            return true;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="retDetailList">RetrievalDetail List (RetID, ItemID, ActualQty)</param>
        /// <returns></returns>
        public bool save(List<RetrievalDetail> retDetailList)
        {
            return true;
        }

    }
}
