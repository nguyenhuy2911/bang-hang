using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class ADJUSTMENT_DETAIL
    {
        public System.Guid ID { get; set; }
        public string Adjustment_ID { get; set; }
        public Nullable< int> Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Stock_ID { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> UnitConvert { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public string Orgin { get; set; }
        public Nullable<decimal> CurrentQty { get; set; }
        public Nullable<decimal> NewQty { get; set; }
        public Nullable<decimal> QtyDiff { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> QtyConvert { get; set; }
        public Nullable<long> StoreID { get; set; }
        public string Batch { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        public Nullable<long> Sorted { get; set; }
        public virtual ADJUSTMENT ADJUSTMENT { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
