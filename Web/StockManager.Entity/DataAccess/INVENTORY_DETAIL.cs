using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class INVENTORY_DETAIL
    {
        public long ID { get; set; }
        public string RefNo { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public Nullable<System.Guid> RefDetailNo { get; set; }
        public Nullable<int> RefType { get; set; }
        public Nullable<int> RefStatus { get; set; }
        public Nullable<long> StoreID { get; set; }
        public string Stock_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Customer_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Batch { get; set; }
        public string Serial { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> E_Qty { get; set; }
        public Nullable<decimal> E_Amt { get; set; }
        public string Description { get; set; }
        public Nullable<long> Sorted { get; set; }
        public string Book_ID { get; set; }
        public virtual INVENTORY INVENTORY { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual STOCK STOCK { get; set; }
    }
}
