using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class OnlineItem_GetList
    {
        public OnlineItem_GetList()
        {
           
        }
        public int ProductId { get; set; }
        public int ProductGroup_ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Sale_Price { get; set; }
        public string ImagePath { get; set; }
        public bool Publish { get; set; }

    }
}
