﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdjustvoucherAPI" in both code and config file together.
    [ServiceContract]
    public interface IAdjustvoucherAPI
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat =  WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/createVoucherAdj")]
        bool createVoucherAdj(AdjustmentVoucher adj);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/createVoucherAdjDetail")]
        bool createVoucherAdjDetail(List<AdjustmentDetail> adjDetail);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat =WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/getAdjVoucher")]
        List<AdjustmentVoucher> getAdjVoucher(string AdjID, string startDate, string endDate);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/getAdjVoucherDetail")]
        List<AdjustmentDetail> getAdjVoucherDetail(string adjId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getAdjVoucherId")]
        string getAdjVoucherId();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                        RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/approveAdj")]
        bool approveAdj(string adjId, string ApprovedBy);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                        RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/rejectAdj")]
        bool rejectAdj(string adjId, string ApprovedBy);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                        RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getAdjVoucherByID")]
        AdjustmentVoucher getAdjVoucherByID(string AdjID);
    }
}
