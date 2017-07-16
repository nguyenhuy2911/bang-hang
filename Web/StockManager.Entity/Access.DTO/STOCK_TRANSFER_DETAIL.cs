using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class STOCK_TRANSFER_DETAIL
    {
        public System.Guid ID { get; set; }
        public string Transfer_ID { get; set; }
        public Nullable<int> RefType { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string OutStock { get; set; }
        public string InStock { get; set; }
        public Nullable<decimal> Lev1 { get; set; }
        public Nullable<decimal> Lev2 { get; set; }
        public Nullable<decimal> Lev3 { get; set; }
        public Nullable<decimal> Lev4 { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitConvert { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> QtyConvert { get; set; }
        public Nullable<long> StoreID { get; set; }
        public string Batch { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        public long Sorted { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual STOCK_TRANSFER STOCK_TRANSFER { get; set; }
    }
}
