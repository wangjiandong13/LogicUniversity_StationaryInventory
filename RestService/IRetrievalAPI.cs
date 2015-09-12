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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRetrievalAPI" in both code and config file together.
    [ServiceContract]
    public interface IRetrievalAPI
    {
    
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                           RequestFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/createRetrieval")]
        int createRetrieval(List<ProcessRetrieval> processRetList);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "/getRetrieval/{EmpID}/{Status}/{RetID}")]
        List<Retrieval> getRetrieval(string EmpID, string Status, string RetID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "/submit")]
        bool submit(List<RetrievalDetail> retDetailList);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "/save")]
        bool save(List<RetrievalDetail> retDetailList);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "/getRetrievalDetail/{RetID}")]
        List<ProcessRetSuccess> getRetrievalDetail(string RetID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "/getReqAllocation/{RetID}")]
        List<ReqAllocation> getReqAllocation(string RetID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "/confirmAllocation")]
        bool confirmAllocation(List<RequisitionDetail> reqDetailList);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getRetByDept/{RetID}")]
        List<ReqAllocation> getRetByDept(string RetID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getStoreClerk")]
        List<Employee> getStoreClerk();
    }
}
