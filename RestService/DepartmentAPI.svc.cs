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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DepartmentAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DepartmentAPI.svc or DepartmentAPI.svc.cs at the Solution Explorer and start debugging.
    public class DepartmentAPI : IDepartmentAPI
    {
        public List<Model.Department> getAllDepartment()
        {
            BusinessLogic.DepartmentController bl = new BusinessLogic.DepartmentController();
            return bl.getAllDept();
        }

        public Model.Department getDeptByID(string DepID)
        {
            BusinessLogic.DepartmentController bl = new BusinessLogic.DepartmentController();
            return bl.getDeptByID(DepID);
        }

        public bool updateDept(Department department)
        {
            BusinessLogic.DepartmentController bl = new BusinessLogic.DepartmentController();
            if (bl.updateDept(department))
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
