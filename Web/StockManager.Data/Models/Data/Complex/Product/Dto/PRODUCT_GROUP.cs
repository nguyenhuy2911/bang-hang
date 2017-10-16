using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class PRODUCT_GROUP
    {
        public PRODUCT_GROUP()
        {
           
        }

        public int ProductGroup_ID { get; set; }
        public string ProductGroup_Name { get; set; }
        public decimal Sale_Price { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }

    }
}
