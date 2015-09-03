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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeAPI" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeAPI
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getemployeebyrole/{role}")]
        List<Employee> getemployeebyrole(string role);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/getemployeebyDeptID/{DeptID}")]
        List<Employee> getemployeebyDeptID(string DeptID);

        [OperationContract]
        [WebInvoke(Method = "POST", 
                           RequestFormat = WebMessageFormat.Json,
                           ResponseFormat = WebMessageFormat.Json,
                           BodyStyle = WebMessageBodyStyle.Bare,
                           UriTemplate = "/login")]
        Employee login(Employee e);
    }
}
