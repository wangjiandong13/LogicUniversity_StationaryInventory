using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RequisitionAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RequisitionAPI.svc or RequisitionAPI.svc.cs at the Solution Explorer and start debugging.
    public class RequisitionAPI : IRequisitionAPI
    {
        public bool approve(int ReqId, int HandledBy, string Remark)
        {
            throw new NotImplementedException();
        }

        public int createRequisition(List<CartItems> itemList)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public List<Requisition> getRequisition(string StatusID, string ReqID, string EmpID)
        {
            throw new NotImplementedException();
        }

        public List<Requisition> getRequisitionList(int DisID)
        {
            throw new NotImplementedException();
        }

        public bool reject(int ReqId, int HandledBy, string Remark)
        {
            throw new NotImplementedException();
        }
    }
}
