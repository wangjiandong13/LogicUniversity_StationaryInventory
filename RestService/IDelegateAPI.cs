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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDelegateAPI" in both code and config file together.
    [ServiceContract]
    public interface IDelegateAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getDelegate/{DeptID}")]
        List<Model.Delegate> getDelegate(string DeptID);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                        RequestFormat =WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/createDelegate")]
        bool createDelegate(string EmpID, string DeptID, string StartDate, string EndDate, string Status);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/deleteDelegate/{DelegateSN}")]
        bool deleteDelegate(string DelegateSN);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
                                        RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.WrappedRequest,
                                           UriTemplate = "/editDelegate")]
        bool editDelegate(string EmpID, string DeptID, string StartDate, string EndDate, string Status);
    }
}
