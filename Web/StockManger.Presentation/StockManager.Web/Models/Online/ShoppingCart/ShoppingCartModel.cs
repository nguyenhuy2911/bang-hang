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
            Cart = new ShoppingCart();
        }
        public ShoppingCart Cart { get; set; }
    }


}