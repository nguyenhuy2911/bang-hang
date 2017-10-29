using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManager.Web.Common;
namespace StockManager.Web.Models.Online
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            var listShoppingItem = (List<ShoppingCartItem>)HttpContext.Current.Session[ConstantKey.SessionCart];
            if (listShoppingItem == null)
                listShoppingItem = new List<ShoppingCartItem>();
            ListItem = listShoppingItem;
        }
        public List<ShoppingCartItem> ListItem { get; set; }
        public bool AddToCart(ShoppingCartItem item)
        {
            bool alreadyExists = false;
            if (ListItem != null)
                alreadyExists = ListItem.Any(x => x.ProductID == item.ProductID);
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
        public decimal Total()
        {
            return ListItem.Sum(x => x.Total);
        }
        public int TotalQuantity()
        {
            return ListItem.Sum(x => x.Quantity);
        }
        public bool EmptyCart()
        {
            ListItem.Clear();
            HttpContext.Current.Session[ConstantKey.SessionCart] = null;
            return true;
        }
    }
    
}