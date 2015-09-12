using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using System.ServiceModel.Web;
using System.Net;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeAPI.svc or EmployeeAPI.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeAPI : IEmployeeAPI
    {
        public List<Employee> getemployeebyDeptID(string DeptID)
        {
            BusinessLogic.EmployeeController BL = new BusinessLogic.EmployeeController();
            return BL.getemployeebyDeptID(DeptID);
        }

        public Employee getemployeebyId(string EmpID)
        {
            BusinessLogic.EmployeeController BL = new BusinessLogic.EmployeeController();
            return BL.getemployeebyId(EmpID);
        }

        public List<Employee> getemployeebyrole(string role)
        {
            BusinessLogic.EmployeeController BL = new BusinessLogic.EmployeeController();
            return BL.getemployeebyrole(role);
        }

        public Employee login(Employee e)
        {
            BusinessLogic.EmployeeController BL = new BusinessLogic.EmployeeController();
            Employee re = BL.login(e);
            if (re != null)
            {
                return re;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                return null;
            }
        }

        public bool updateemployeeRole(string EmpId, string role)
        {
            BusinessLogic.EmployeeController BL = new BusinessLogic.EmployeeController();
            if (BL.updateEmployeeRole(EmpId, role))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotFound;
                return false;
            }
        }
    }
}
