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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoryAPI.svc or InventoryAPI.svc.cs at the Solution Explorer and start debugging.
    public class InventoryAPI : IInventoryAPI
    {
        public bool createItem(Item item)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            if (BL.createItem(item))
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

        public bool createItemPrice(List<ItemPrice> ip)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            if (BL.createItemPrice(ip))
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

        public List<Item> getItem()
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getItem();
        }

        public List<Item> getItemByCategory(string category)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getItemByCategory(category);
        }

        public List<Item> getItemByName(string itemName)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getItemByName(itemName);
        }

        public Item getItemDetails(string itemID)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getItemDetails(itemID);
        }

        public List<Model.ItemPrice> getItemPrice(string ItemID)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getItemPrice(ItemID);
        }

        public List<Model.StockCard> getStockCard(string itemID)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getStockCard(itemID);
        }

        public bool updateItem(Item item)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            if (BL.updateItem(item))
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
        

        public bool updateItemPrice(List<ItemPrice> itemprice)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            if (BL.updateItemPrice(itemprice))
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
