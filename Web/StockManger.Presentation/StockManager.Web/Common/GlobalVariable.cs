using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Common
{
    public class GlobalVariable
    {
        public static List<Product_DTO> _listItem { get; set; }
    }
}