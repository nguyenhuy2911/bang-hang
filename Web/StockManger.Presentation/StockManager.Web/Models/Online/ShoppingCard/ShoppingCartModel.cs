using StockManager.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace StockManager.Web.Models.Online
{
    public class ShoppingCartModel
    {
        public ShoppingCartModel()
        {

        }
        public List<ShoppingCartItem> ListItem
        {
            get
            {
                var listShoppingItem = HttpContext.Current.Session[ConstantKey.SessionCart];
                if (listShoppingItem == null)
                    listShoppingItem = new List<ShoppingCartItem>();

                return (List<ShoppingCartItem>)listShoppingItem;
            }
            set { }
        }
        public bool AddToCart(ShoppingCartItem item)
        {
            bool alreadyExists = ListItem.Any(x => x.ProductID == item.ProductID);
            if (alreadyExists)
            {
                ShoppingCartItem existsItem = ListItem.Where(x => x.ProductID == item.ProductID).SingleOrDefault();
                if (existsItem != null)
                {
                    UpdateQuantity(item.ProductID, item.Quantity);
                }
            }
            else
            {
                ListItem.Add(item);
            }
            HttpContext.Current.Session[ConstantKey.SessionCart] = ListItem;
            return true;
        }
        public bool RemoveFromCart(long lngProductSellID)
        {
            ShoppingCartItem existsItem = ListItem.Where(x => x.ProductID == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                ListItem.Remove(existsItem);
            }
            HttpContext.Current.Session[ConstantKey.SessionCart] = ListItem;
            return true;
        }
        public bool UpdateQuantity(long lngProductSellID, int intQuantity)
        {
            ShoppingCartItem existsItem = ListItem.Where(x => x.ProductID == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                existsItem.Quantity = intQuantity;
            }
            HttpContext.Current.Session[ConstantKey.SessionCart] = ListItem;
            return true;
        }
        public decimal GetTotal()
        {
            return ListItem.Sum(x => x.Total);
        }
        public int GetTotalQuantity()
        {
            return ListItem.Sum(x => x.Quantity);
        }
        public bool EmptyCart()
        {
            ListItem.Clear();
            return true;
        }
    }


}