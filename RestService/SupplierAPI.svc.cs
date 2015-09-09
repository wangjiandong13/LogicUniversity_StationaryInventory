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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SupplierAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SupplierAPI.svc or SupplierAPI.svc.cs at the Solution Explorer and start debugging.
    public class SupplierAPI : ISupplierAPI
    {
        public bool createSupplier(Supplier s)
        {
            BusinessLogic.SupplierController BL = new BusinessLogic.SupplierController();
            if (BL.createSupplier(s))
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

        public bool deleteSupplier(string supplierId)
        {
            BusinessLogic.SupplierController BL = new BusinessLogic.SupplierController();
            if (BL.deleteSupplier(supplierId))
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

        public Supplier getBySupplierID(string supplierid)
        {
            BusinessLogic.SupplierController BL = new BusinessLogic.SupplierController();
            return BL.getBySupplierID(supplierid);
        }

        public List<Supplier> getSupplierList()
        {
            BusinessLogic.SupplierController BL = new BusinessLogic.SupplierController();
            return BL.getSupplierList();
        }

        public bool updateSupplier(Supplier s)
        {
            BusinessLogic.SupplierController BL = new BusinessLogic.SupplierController();
            if (BL.updateSupplier(s))
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

        public bool updateSupplierRank(string supplierId, string rank)
        {
            BusinessLogic.SupplierController BL = new BusinessLogic.SupplierController();
            if (BL.updateSupplierRank(supplierId,rank))
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
