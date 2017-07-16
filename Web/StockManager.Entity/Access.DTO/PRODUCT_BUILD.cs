using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class PRODUCT_BUILD
    {
        public string ProductID { get; set; }
        public string BuildID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
