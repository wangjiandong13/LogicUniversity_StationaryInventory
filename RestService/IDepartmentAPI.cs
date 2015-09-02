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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDepartmentAPI" in both code and config file together.
    [ServiceContract]
    public interface IDepartmentAPI
    {
        /// <summary>
        /// Get All Department
        /// </summary>
        /// <returns>List of Department</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getAllDepartment")]
        List<Department> getAllDepartment();

        /// <summary>
        /// Get Department By ID
        /// </summary>
        /// <param name="DepID"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/getDeptByID/{DeptID}")]
        Department getDeptByID(String DepID);

        /// <summary>
        /// Edit Department
        /// </summary>
        /// <param name="dept">Department model</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                                           RequestFormat = WebMessageFormat.Json,
                                           BodyStyle = WebMessageBodyStyle.Bare,
                                           UriTemplate = "/editDepartment")]
        Boolean editDepartment(Department dept);
    }
}
