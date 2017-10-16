using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class Product_GetList_Level2
    {
        public Product_GetList_Level2()
        {
           
        }
        public int ProductId { get; set; }
        public int Product_Level1 { get; set; }
        public int Product_Level2 { get; set; }
        public string Product_Name { get; set; }
        public decimal Sale_Price { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }

    }
}
