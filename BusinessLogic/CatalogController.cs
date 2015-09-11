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

        /// <summary>
        /// GetCategory
        /// </summary>
        /// <returns></returns>
        public List<Model.ItemCategory> getCategory()
        {
            return ctx.ItemCategory.ToList();
        }

        /// <summary>
        /// SearchItem
        /// </summary>
        /// <returns></returns>
        public List<Model.Item> searchItem(string ItemCatID, string ItemName)
        {
            if (ItemCatID == "null")
                ItemCatID = null;
            if (ItemName == "null")
                ItemName = null;

            //start with all the records
            var query = from req in ctx.Item select req;

            //filter the result set based on user inputs
            if (!string.IsNullOrEmpty(ItemCatID))
            {
                query = query.Where(x => x.ItemCatID.ToString().Contains(ItemCatID));
            }
            if (!string.IsNullOrEmpty(ItemName))
            {
                query = query.Where(x => x.ItemName.ToString().Contains(ItemName));
            }

            //run the query on database and grab the results
            return query.ToList();
        }
        


    }

}
