using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class STOCK_BUILD_DETAIL
    {
        public System.Guid ID { get; set; }
        public string Build_ID { get; set; }
        public string Product_ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> RefType { get; set; }
        public Nullable<int> RefTypeSub { get; set; }
        public string Stock_ID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitConvert { get; set; }
        public Nullable<int> Vat { get; set; }
        public Nullable<decimal> CurrentQty { get; set; }
        public Nullable<decimal> QuantityDefault { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> QtyConvert { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Charge { get; set; }
        public Nullable<System.DateTime> Limit { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        public long Sorted { get; set; }
        public virtual STOCK_BUILD STOCK_BUILD { get; set; }
    }
}
