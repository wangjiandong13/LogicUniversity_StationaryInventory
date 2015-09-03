using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CatalogAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CatalogAPI.svc or CatalogAPI.svc.cs at the Solution Explorer and start debugging.
    public class CatalogAPI : ICatalogAPI
    {
        public List<Item> getItem()
        {
            BusinessLogic.CatalogController bl = new BusinessLogic.CatalogController();
            return bl.getItem();
        }

        public List<Item> getItemCategory(string category)
        {
            BusinessLogic.CatalogController bl = new BusinessLogic.CatalogController();
            return bl.getItemByCategory(category);
        }
    }
}
