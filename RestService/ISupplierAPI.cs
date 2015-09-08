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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISupplierAPI" in both code and config file together.
    [ServiceContract]
    public interface ISupplierAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedResponse,
                                           UriTemplate = "/getSupplierList/{DisID}")]
        List<Supplier> getSupplierList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getBySupplierID/{supplierid}")]
        Supplier getBySupplierID(string supplierid);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                                   BodyStyle = WebMessageBodyStyle.Bare,
                                                   UriTemplate = "/createSupplier")]
        bool createSupplier(Supplier s);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                                   BodyStyle = WebMessageBodyStyle.Bare,
                                                   UriTemplate = "/updateSupplier")]
        bool updateSupplier(Supplier s);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/updateSupplierRank/{supplierId}/{rank}")]
        bool updateSupplierRank(string supplierId, string rank);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/deleteSupplier/{supplierId}")]
        bool deleteSupplier(string supplierId);
    }
}
