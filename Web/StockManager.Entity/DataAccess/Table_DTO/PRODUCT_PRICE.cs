using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class PRODUCT_PRICE
    {
        public System.Guid ID { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public Nullable<short> RefStatus { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.Guid> ProductID { get; set; }
        public Nullable<System.Guid> CustomerID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public Nullable<decimal> CommissionRate { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> BeginAmount { get; set; }
        public Nullable<decimal> EndAmount { get; set; }
        public Nullable<bool> IsPublic { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string OwnerID { get; set; }
        public string Description { get; set; }
        public Nullable<long> Sorted { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
