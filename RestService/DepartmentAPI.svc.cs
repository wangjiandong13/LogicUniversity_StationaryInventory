using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DepartmentAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DepartmentAPI.svc or DepartmentAPI.svc.cs at the Solution Explorer and start debugging.
    public class DepartmentAPI : IDepartmentAPI
    {
        public bool editDepartment(Model.Department dept)
        {
            return true;
        }

        public List<Model.Department> getAllDepartment()
        {
            BusinessLogic.DepartmentController bl = new BusinessLogic.DepartmentController();
            return bl.getAllDept();
        }

        public Model.Department getDeptByID(String DepID)
        {
            BusinessLogic.DepartmentController bl = new BusinessLogic.DepartmentController();
            return bl.getDeptByID(DepID);
        }
    }
}
