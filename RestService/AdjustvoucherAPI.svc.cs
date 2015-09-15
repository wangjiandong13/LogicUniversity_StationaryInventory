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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdjustvoucherAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdjustvoucherAPI.svc or AdjustvoucherAPI.svc.cs at the Solution Explorer and start debugging.
    public class AdjustvoucherAPI : IAdjustvoucherAPI
    {
        public bool approveAdj(string AdjID, string ApprovedBy)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            if (BL.approveAdj(AdjID, ApprovedBy))
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

        public bool createVoucherAdj(AdjustmentVoucher adj)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            if (BL.createVoucherAdj(adj))
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

        public bool createVoucherAdjDetail(List<AdjustmentDetail> adjDetail)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            if (BL.createVoucherAdjDetail(adjDetail))
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

        public List<AdjustmentVoucher> getAdjVoucher(string AdjID, string startDate, string endDate)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            return BL.getAdjVoucher(AdjID,startDate,endDate);
        }

        public AdjustmentVoucher getAdjVoucherByID(string AdjID)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            return BL.getAdjVoucherByID(AdjID);
        }

        public List<AdjustmentDetail> getAdjVoucherDetail(string adjId)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            return BL.getAdjVoucherDetail(adjId);
        }

        public string getAdjVoucherId()
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            return BL.getAdjVoucherId();
        }

        public bool rejectAdj(string AdjID, string ApprovedBy)
        {
            BusinessLogic.AdjustVoucherController BL = new BusinessLogic.AdjustVoucherController();
            if (BL.rejectAdj(AdjID, ApprovedBy))
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
