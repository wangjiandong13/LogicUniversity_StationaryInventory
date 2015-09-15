using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// UI 4.7 , 4.7.1 Store Clerk : Inventory List & Tile
    /// UI 4.7 Store Clerk : Inventory List
    /// </summary>
   public class InventoryController
    {
        Model.StationeryInventory_Team_05Entities ctx = new Model.StationeryInventory_Team_05Entities();

        /// <summary>
        /// get all items without choosing category (UI 4.7)
        /// </summary>
        /// <returns></returns>
        public List<Model.Item> getItem()
        {
            var item = from c in ctx.Item
                       select c;

            return item.ToList();
        }

        public List<Model.Item> getFirst20Items()
        {
            var items = (from c in ctx.Item
                         orderby c.ItemID ascending
                         select c).Take(20);

            return items.ToList();
        }

        public List<Model.Item> get20Items(string count) 
        {
            
            var items = (from c in ctx.Item 
                         orderby c.ItemID ascending
                         select c).Skip(20*Convert.ToInt32(count)).Take(20);

            return items.ToList();
        }

         
        /// <summary>
        /// get item details (UI 4.7.3)
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public Model.Item getItemDetails(string itemID)
        {
            Model.Item items = (from c in ctx.Item
                                         where c.ItemID == itemID
                                         select c).First();

            return items;
        }

        /// <summary>
        /// get items by category(UI 4.7)
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Model.Item> getItemByCategory(string category)
        {
            Model.ItemCategory cat = new Model.ItemCategory();
            cat = (from c in ctx.ItemCategory
                   where c.ItemDescription == category
                   select c).First();

            var items = from c in ctx.Item
                        where cat.ItemCatID == c.ItemCatID
                        select c;
            return items.ToList();
        }

        /// <summary>
        /// search item by name (UI 4.7)
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public List<Model.Item> getItemByName(string itemName)
        {
            var items = from c in ctx.Item
                        where (c.ItemName.Contains(itemName))
                        select c;
            return items.ToList();
        }

        /// <summary>
        /// Creating Item Details UI 4.7.2 Inventory New
        /// </summary>
        /// <param name="item">Item Object</param>
        /// <returns></returns>
        public bool createItem(Model.Item item)
        {
            bool result = true;

            //Add item obj to db
            ctx.Item.Add(item);
            
            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Creating Item Details UI 4.7.2 Inventory New
        /// </summary>
        /// <param name="ip">ItemPrice object (ItemID, SupplierID, Price)</param>
        /// <returns></returns>
        public bool createItemPrice(List<Model.ItemPrice> ip)
        {
            bool result = true;

            //add item price
            foreach (Model.ItemPrice itemprice in ip){
                ctx.ItemPrice.Add(itemprice);
            }

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// UI 4.7.3 SC : Inventory Stock Card by item ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public List<Model.StockCard> getStockCard(string itemID)
        {
            List<Model.StockCard> stockcardList = (from c in ctx.StockCard
                                         where c.ItemID == itemID
                                         select c).ToList();

            return stockcardList;
        }

        /// <summary>
        /// UpdateItem Details 
        /// </summary>
        /// <param name="item">item object (ItemID, ItemName, ItemCatID, RoLvl, RoQty, UOM, Stock, Bin )</param>
        /// <returns></returns>
        public bool updateItem(Model.Item item)
        {
            bool result = true;

            Model.Item i = ctx.Item.Where(x => x.ItemID == item.ItemID).FirstOrDefault();

            if(item.ItemName != null)
                i.ItemName = item.ItemName;
            if (item.ItemCatID != null)
                i.ItemCatID = item.ItemCatID;
            if (item.RoLvl != null)
                i.RoLvl = item.RoLvl;
            if (item.RoQty != null)
                i.RoQty = item.RoQty;
            if (item.UOM != null)
                i.UOM = item.UOM;
            if (item.Stock != null)
                i.Stock = item.Stock;
            if (item.Bin != null)
                i.Bin = item.Bin;

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// UpdateItem Details 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemprice"></param>
        /// <returns></returns>
        public bool updateItemPrice(List<Model.ItemPrice> itemprice)
        {
            bool result = true;
            
            foreach (Model.ItemPrice ip in itemprice)
            {
                Model.ItemPrice ipSearch = ctx.ItemPrice.Where(x => x.ItemID == ip.ItemID && x.SupplierID == ip.SupplierID).FirstOrDefault();
                ipSearch.Price = ip.Price;
            }
            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public List<Model.ItemPrice> getItemPrice(string ItemID)
        {
            return ctx.ItemPrice.Where(x => x.ItemID == ItemID).ToList();
        }

        /// <summary>
        /// deleteItem
        /// </summary>
        /// <param name="ItemID">Item ID</param>
        /// <returns></returns>
        public bool deleteItem(string ItemID)
        {
            bool result = true;

            Model.Item item = ctx.Item.Where(x => x.ItemID == ItemID).FirstOrDefault();
            ctx.Item.Remove(item);

            List<Model.ItemPrice> itemPriceList = ctx.ItemPrice.Where(x => x.ItemID == ItemID).ToList();
            foreach(Model.ItemPrice itemPrice in itemPriceList)
            {
                ctx.ItemPrice.Remove(itemPrice);
            }

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
