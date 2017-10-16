using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class STOCK_INWARD_DETAIL
    {
        public System.Guid ID { get; set; }
        public string Inward_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> RefType { get; set; }
        public string Stock_ID { get; set; }
        public Nullable<decimal> Lev1 { get; set; }
        public Nullable<decimal> Lev2 { get; set; }
        public Nullable<decimal> Lev3 { get; set; }
        public Nullable<decimal> Lev4 { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitConvert { get; set; }
        public Nullable<int> Vat { get; set; }
        public Nullable<decimal> CurrentQty { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> QtyConvert { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Charge { get; set; }
        public Nullable<System.DateTime> Limit { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public string Orgin { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Batch { get; set; }
        public string Serial { get; set; }
        public string ChassyNo { get; set; }
        public string IME { get; set; }
        public Nullable<long> StoreID { get; set; }
        public string Description { get; set; }
        public long Sorted { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual STOCK_INWARD STOCK_INWARD { get; set; }
    }
}
