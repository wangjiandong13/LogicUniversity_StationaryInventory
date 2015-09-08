using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class RequestCartController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// AddItem
        /// </summary>
        /// <param name="item">CartItem (EmpID, ItemID, Qty)</param>
        /// <returns></returns>
        public bool addItem(CartItems item)
        {
            bool result = false;

            CartItems cartItem = new CartItems();
            cartItem.EmpID = item.EmpID;
            cartItem.ItemID = item.ItemID;
            cartItem.Qty = item.Qty;

            ctx.CartItems.Add(cartItem);
            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// UpdateItem
        /// </summary>
        /// <param name="item">CartItem (EmpID, ItemID, Qty)</param>
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
        /// <param name="item">CartItem (EmpID, ItemID)</param>
        /// <returns></returns>
        public bool deleteItem(CartItems item)
        {
            bool result = false;

            CartItems cartItem = ctx.CartItems.Where(x => x.EmpID == item.EmpID && x.ItemID == item.ItemID).FirstOrDefault();

            if (cartItem == null)
                return result;

            ctx.CartItems.Remove(cartItem);
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
            List<CartItems> result = ctx.CartItems.Where(x => x.EmpID == Convert.ToInt32(EmpID)).ToList();

            return result;
        }

    }
}
