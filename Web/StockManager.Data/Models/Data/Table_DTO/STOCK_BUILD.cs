using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class STOCK_BUILD
    {
        public STOCK_BUILD()
        {
            this.STOCK_BUILD_DETAIL = new List<STOCK_BUILD_DETAIL>();
        }

        public string ID { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string Ref_OrgNo { get; set; }
        public Nullable<int> RefType { get; set; }
        public string Barcode { get; set; }
        public string Department_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Contact { get; set; }
        public string Reason { get; set; }
        public string Currency_ID { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public Nullable<int> Vat { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> FAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Charge { get; set; }
        public string Description { get; set; }
        public string User_ID { get; set; }
        public Nullable<long> Sorted { get; set; }
        public virtual ICollection<STOCK_BUILD_DETAIL> STOCK_BUILD_DETAIL { get; set; }
    }
}
