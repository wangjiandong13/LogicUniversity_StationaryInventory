using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAnalyticsAPI" in both code and config file together.
    [ServiceContract]
    public interface IAnalyticsAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getReports")]
        List<Model.Report> getReports();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getReport/{reportID}")]
        Model.Report getReport(string reportID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/updateReport")]
        bool updateReport(Model.Report rp);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                    RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/generateNewReport")]
        string generateNewReport(string EmpID, string Title, string StartD, string EndD, string Remark, string Type, string Criteria, string Precriteria);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/generateExistingReport/{reportID}")]
        List<Model.ReportResult> generateExistingReport(string reportID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/generateExistingReportStyle2/{reportID}")]
        List<Model.ReportResult> generateExistingReportStyle2(string reportID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/generateExistingReportStyle3/{reportID}/{type}")]
        List<Model.ReportResultWeb> generateExistingReportStyle3(string reportID, string type);
    }
}
