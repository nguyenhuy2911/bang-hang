using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class TRANS_REF
    {
        public System.Guid ID { get; set; }
        public string RefID { get; set; }
        public string RefOrgNo { get; set; }
        public Nullable<int> RefType { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string TransFrom { get; set; }
        public string TransTo { get; set; }
        public string Department_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Stock_ID { get; set; }
        public string Branch_ID { get; set; }
        public string Contract_ID { get; set; }
        public string Contract { get; set; }
        public string Reason { get; set; }
        public string Currency_ID { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> FAmount { get; set; }
        public Nullable<decimal> FDiscount { get; set; }
        public Nullable<bool> IsClose { get; set; }
        public Nullable<long> Sorted { get; set; }
        public string Description { get; set; }
        public string User_ID { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
