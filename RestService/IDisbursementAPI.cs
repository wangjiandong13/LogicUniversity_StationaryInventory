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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDisbursementAPI" in both code and config file together.
    [ServiceContract]
    public interface IDisbursementAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getDisbursementDetail/{DisID}")]
        DisbursementDetail getDisbursementDetail(int DisID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getDisbursement/{DeptID}/{CPID}/{DisID}/{startdate}/{enddate}")]
        List<Disbursement> getDisbursement(string DeptID, string CPID, string DisID, string startdate, string enddate);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/createDisbursement/{EmpID}")]
        bool createDisbursement(int EmpID);
    }
}
