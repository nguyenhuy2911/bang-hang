using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.PRODUCT
{
    public class Products_ViewModel : BaseModel
    {
        public Products_ViewModel()
        {
            FunctionName = "Products";
        }
        public string GridHeader { get; set; }
    }
}