using Model;
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
                                           UriTemplate = "/createVoucher")]
        bool createVoucher(AdjustmentVoucher adj, List<AdjustmentDetail> adjDetail);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getAdjVoucher/{AdjID}/{startdate}/{enddate}")]
        List<AdjustmentVoucher> getAdjVoucher(string AdjID, DateTime startDate, DateTime endDate);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getAdjVoucherDetail/{AdjID}")]
        List<AdjustmentDetail> getAdjVoucherDetail(string adjId);
    }
}
