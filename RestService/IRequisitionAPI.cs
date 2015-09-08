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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRequisitionAPI" in both code and config file together.
    [ServiceContract]
    public interface IRequisitionAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getRequisitionList/{DisID}")]
        List<Requisition> getRequisitionList(string DisID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/approve/{ReqId}/{HandledBy}/{Remark}")]
        bool approve(string ReqId, string HandledBy, string Remark);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/reject/{ReqId}/{HandledBy}/{Remark}")]
        bool reject(string ReqId, string HandledBy, string Remark);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getRequisition/{StatusID}/{ReqID}/{EmpID}")]
        List<Requisition> getRequisition(string StatusID, string ReqID, string EmpID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/createRequisition")]
        int createRequisition(List<CartItems> itemList);


    }
}
