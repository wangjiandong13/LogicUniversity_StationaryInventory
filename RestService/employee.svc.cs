using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "employee" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select employee.svc or employee.svc.cs at the Solution Explorer and start debugging.
    public class employee : Iemployee
    {
        public void DoWork()
        {
            BusinessLogic.Employee em = new BusinessLogic.Employee();
        }
    }
}
