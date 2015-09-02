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
        /// <param name="item"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool createItemDetails(Model.Item item,List<Model.ItemPrice> ip)
        {
            //Add item obj to db
            ctx.Item.Add(item);

            //add item price
            //loop
            foreach (Model.ItemPrice  itemprice in ip){
                ctx.ItemPrice.Add(itemprice);
            }

            ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// UI 4.7.3 SC : Inventory Stock Card by item ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public Model.StockCard getStockCard(string itemID)
        {
            Model.StockCard stockcard = (from c in ctx.StockCard
                                         where c.ItemID == itemID
                                         select c).First();

            return stockcard;
        }

        /// <summary>
        /// UpdateItem Details 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemprice"></param>
        /// <returns></returns>
        public bool updateItemDetail(Model.Item item, List<Model.ItemPrice> itemprice)
        {
            Model.Item i = new Model.Item();
            Model.ItemPrice ip = new Model.ItemPrice();
            i = (from c in ctx.Item
                 where item.ItemID == i.ItemID
                 select c).First();

            i.ItemName = item.ItemName;
            i.ItemCatID = item.ItemCatID;
            i.RoLvl = item.RoLvl;
            i.RoQty = item.RoQty;
            i.UOM = item.UOM;
            i.Bin = item.Bin;

            foreach (Model.ItemPrice ip1 in itemprice)
            {
                ip.Price = ip1.Price;
            }

            ctx.SaveChanges();
            return true;
        }

    }
}
