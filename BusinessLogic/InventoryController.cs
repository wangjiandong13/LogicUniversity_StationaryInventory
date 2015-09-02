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
    class InventoryController
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

        public bool createItemDetails(Model.Item i, Model.ItemPrice ip)
        {
            //Model.ItemCategory cat = new Model.ItemCategory();
            //if (i.ItemCatID == cat.ItemCatID)
            //{
            //    cat.ItemDescription = category;
            //}

            ctx.Item.Add(i);
            ctx.SaveChanges();
            return true;
        }

        public Model.StockCard getStockCard(string itemID)
        {
            Model.StockCard stockcard = (from c in ctx.StockCard
                                         where c.ItemID == itemID
                                         select c).First();

            return stockcard;
        }

    }
}
