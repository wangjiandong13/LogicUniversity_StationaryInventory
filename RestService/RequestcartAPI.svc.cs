using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RequestcartAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RequestcartAPI.svc or RequestcartAPI.svc.cs at the Solution Explorer and start debugging.
    public class RequestcartAPI : IRequestcartAPI
    {
        public bool addItem(CartItems item)
        {
            BusinessLogic.RequestCartController BL = new BusinessLogic.RequestCartController();
            return BL.addItem(item);
        }

        public bool deleteItem(CartItems item)
        {
            BusinessLogic.RequestCartController BL = new BusinessLogic.RequestCartController();
            return BL.deleteItem(item);
        }

        public bool updateItem(CartItems item)
        {
            BusinessLogic.RequestCartController BL = new BusinessLogic.RequestCartController();
            return BL.updateItem(item);
        }
    }
}
