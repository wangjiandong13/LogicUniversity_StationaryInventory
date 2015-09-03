using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// UI 2.2.1 Employee : Catalog
    /// </summary>
   public class CatalogController
    {
        Model.StationeryInventory_Team_05Entities ctx = new Model.StationeryInventory_Team_05Entities();

        /// <summary>
        /// get all items without choosing category 
        /// </summary>
        /// <returns></returns>
        public List<Model.Item> getItem()
        {
            var item = from c in ctx.Item
                       select c;

            return item.ToList();
        }

        /// <summary>
        /// get items by category
        /// </summary>
        /// <param name="category">Category Description</param>
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
        /// search item by name
        /// </summary>
        /// <param name="itemName">Item Name</param>
        /// <returns></returns>
        public List<Model.Item> getItemByName(string itemName)
        {
            var items = from c in ctx.Item
                        where (c.ItemName.Contains(itemName))
                        select c;
            return items.ToList();
        }

    }

}
