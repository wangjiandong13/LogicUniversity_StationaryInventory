using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoryAPI.svc or InventoryAPI.svc.cs at the Solution Explorer and start debugging.
    public class InventoryAPI : IInventoryAPI
    {
        public bool createItemDetails(Item item, List<ItemPrice> ip)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.createItemDetails(item, ip);
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

        public StockCard getStockCard(string itemID)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.getStockCard(itemID);
        }

        public bool updateItemDetail(Item item, List<ItemPrice> ip)
        {
            BusinessLogic.InventoryController BL = new BusinessLogic.InventoryController();
            return BL.updateItemDetail(item,ip);
        }
    }
}
