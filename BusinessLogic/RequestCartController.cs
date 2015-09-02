using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    class RequestCartController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// AddItem
        /// </summary>
        /// <param name="item">CartItem</param>
        /// <returns></returns>
        public bool addItem(CartItems item)
        {
            bool result = false;

            ctx.CartItems.Add(item);
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// UpdateItem
        /// </summary>
        /// <param name="item">CartItem</param>
        /// <returns></returns>
        public bool updateItem(CartItems item)
        {
            bool result = false;

            CartItems cartItem = ctx.CartItems.Where(x => x.EmpID == item.EmpID && x.ItemID == item.ItemID).FirstOrDefault();

            cartItem.Qty = item.Qty;
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// DeleteItem
        /// </summary>
        /// <param name="item">CartItem</param>
        /// <returns></returns>
        public bool deleteItem(CartItems item)
        {
            bool result = false;

            ctx.CartItems.Remove(item);
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// GetItems
        /// </summary>
        /// <param name="EmpID">EmployeeID</param>
        /// <returns></returns>
        public List<CartItems> getItems(string EmpID)
        {
            List<CartItems> result = ctx.CartItems.Where(x => x.EmpID == EmpID).ToList();

            return result;
        }

    }
}
