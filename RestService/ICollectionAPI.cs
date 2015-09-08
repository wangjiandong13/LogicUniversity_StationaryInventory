using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollectionAPI" in both code and config file together.
    [ServiceContract]
    public interface ICollectionAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getCollectionPoint")]
        List<Model.CollectionPoint> getCollectionPoint();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getCollectionPointbyID/{CPID}")]
        List<Model.CollectionPoint> getCollectionPointbyID(string CPID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, 
                                    RequestFormat =WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Wrapped,
                                           UriTemplate = "/updateCollectionPoint")]
        bool updateCollectionPoint(string DeptID, string CPID);
    }
}
