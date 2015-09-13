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
                           UriTemplate = "/getRequisitionbyId/{RetID}")]
        List<Requisition> getRequisitionbyId(string RetID);

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

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/setReqPriority/{ReqID}/{PriorityID}/{Remark}")]
        bool setReqPriority(string ReqID, string PriorityID, string Remark);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "/deleteRequisition/{ReqID}")]
        bool deleteRequisition(string ReqID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getRequisitionDetail/{ReqID}")]
        List<RequisitionDetail> getRequisitionDetail(string ReqID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getstatus")]
        List<Status> getstatus();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getRequisitionByReqID/{ReqID}")]
        Requisition getRequisitionByReqID(string ReqID);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getPriorityName/{PriorityID}")]
        string getPriorityName(string PriorityID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getItemsToReorder/{ReqID}/{EmpID}")]

        List<CartItems> getItemsToReorder(string ReqID, string EmpID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                           RequestFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/confirmReorder")]
        bool confirmReorder(List<CartItems> ItemList);
    }
}
