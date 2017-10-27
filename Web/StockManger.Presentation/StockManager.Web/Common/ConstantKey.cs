using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Common
{
    public class ConstantKey
    {
        public static string SessionCart = "ShoppingCart";
        public static string TembItemDetail = "TembItemDetail";
        public static List<Product_DTO> ListItem { get; set; }

    }
}