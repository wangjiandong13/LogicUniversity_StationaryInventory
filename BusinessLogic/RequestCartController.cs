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
            bool result = true;

            CartItems cartItem = new CartItems();
            cartItem.EmpID = item.EmpID;
            cartItem.ItemID = item.ItemID;
            cartItem.Qty = item.Qty;

            ctx.CartItems.Add(cartItem);
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
        /// UpdateItem
        /// </summary>
        /// <param name="item">CartItem (EmpID, ItemID, Qty)</param>
        /// <returns></returns>
        public bool updateItem(CartItems item)
        {
            bool result = true;

            CartItems cartItem = ctx.CartItems.Where(x => x.EmpID == item.EmpID && x.ItemID == item.ItemID).FirstOrDefault();

            cartItem.Qty = item.Qty;

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
        /// DeleteItem
        /// </summary>
        /// <param name="item">CartItem (EmpID, ItemID)</param>
        /// <returns></returns>
        public bool deleteItem(CartItems item)
        {
            bool result = true;

            CartItems cartItem = ctx.CartItems.Where(x => x.EmpID == item.EmpID && x.ItemID == item.ItemID).FirstOrDefault();

            if (cartItem == null)
                return result;

            ctx.CartItems.Remove(cartItem);
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
        /// GetItems
        /// </summary>
        /// <param name="EmpID">EmployeeID</param>
        /// <returns></returns>
        public List<RequestCart> getItems(string EmpID)
        {
            int empID = Convert.ToInt32(EmpID);
            List<CartItems> cartItemsList = ctx.CartItems.Where(x => x.EmpID == empID).ToList();
            List<RequestCart> requestCartList = new List<RequestCart>();

            foreach(CartItems cartItem in cartItemsList)
            {
                Item item = ctx.Item.Where(x => x.ItemID == cartItem.ItemID).FirstOrDefault();

                RequestCart reqCart = new RequestCart();
                reqCart.ItemID = cartItem.ItemID;
                reqCart.ItemName = item.ItemName;
                reqCart.UOM = item.UOM;
                reqCart.Qty = (int) cartItem.Qty;
            }

            return requestCartList;
        }

    }
}
