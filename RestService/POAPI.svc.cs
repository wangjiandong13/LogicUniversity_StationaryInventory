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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "POAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select POAPI.svc or POAPI.svc.cs at the Solution Explorer and start debugging.
    public class POAPI : IPOAPI
    {
        public bool generatePo(List<ProposePo> proposePoList)
        {
            BusinessLogic.PurchaseOrderController BL = new BusinessLogic.PurchaseOrderController();

            if (BL.generatePo(proposePoList))
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

        public List<PurchaseOrder> getPo(string startdate, string enddate, string EmpID, string PoID)
        {
            BusinessLogic.PurchaseOrderController BL = new BusinessLogic.PurchaseOrderController();
            return BL.getPo(startdate,enddate,EmpID,PoID);
        }

        public List<PurchaseOrderDetail> getPoDetail(string PoID)
        {
            BusinessLogic.PurchaseOrderController BL = new BusinessLogic.PurchaseOrderController();
            return BL.getPoDetail(PoID);
        }

        public List<ProposePo> propose()
        {
            BusinessLogic.PurchaseOrderController BL = new BusinessLogic.PurchaseOrderController();
            return BL.propose();
        }

        public bool restock(List<PurchaseOrderDetail> PoDetailList)
        {
            BusinessLogic.PurchaseOrderController BL = new BusinessLogic.PurchaseOrderController();
            if (BL.restock(PoDetailList))
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
    }
}
