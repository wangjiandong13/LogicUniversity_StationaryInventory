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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DelegateAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DelegateAPI.svc or DelegateAPI.svc.cs at the Solution Explorer and start debugging.
    public class DelegateAPI : IDelegateAPI
    {
        public bool deleteDelegate(string EmpName)
        {
            BusinessLogic.DelegateController BL = new BusinessLogic.DelegateController();
            if (BL.deleteDelegate(EmpName))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotAcceptable;
                return false;
            }
        }

        public bool createDelegate(Model.Delegate dele)
        {
            BusinessLogic.DelegateController BL = new BusinessLogic.DelegateController();
            if (BL.createDelegate(dele))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotAcceptable;
                return false;
            }
        }

        public List<Model.Delegate> getDelegate(string DeptID)
        {
            BusinessLogic.DelegateController BL = new BusinessLogic.DelegateController();

            return BL.getDelegate(DeptID);
        }

        public bool editDelegate(Model.Delegate dele)
        {
            BusinessLogic.DelegateController BL = new BusinessLogic.DelegateController();
            if (BL.editDelegate(dele))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.OK;
                return true;
            }
            else
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.NotAcceptable;
                return false;
            }
        }
    }
}
