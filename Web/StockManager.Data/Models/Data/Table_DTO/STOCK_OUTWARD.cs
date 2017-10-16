using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class STOCK_OUTWARD
    {
        public STOCK_OUTWARD()
        {
            this.STOCK_OUTWARD_DETAIL = new List<STOCK_OUTWARD_DETAIL>();
        }

        public string ID { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string Ref_OrgNo { get; set; }
        public Nullable<int> RefType { get; set; }
        public string Barcode { get; set; }
        public string Department_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Stock_ID { get; set; }
        public string Branch_ID { get; set; }
        public string Contract_ID { get; set; }
        public string Customer_ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Contact { get; set; }
        public string Reason { get; set; }
        public Nullable<short> Payment { get; set; }
        public string Currency_ID { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Charge { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Profit { get; set; }
        public string User_ID { get; set; }
        public Nullable<bool> IsClose { get; set; }
        public Nullable<long> Sorted { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<STOCK_OUTWARD_DETAIL> STOCK_OUTWARD_DETAIL { get; set; }
    }
}
