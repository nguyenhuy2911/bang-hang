using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class STOCK_TRANSFER
    {
        public STOCK_TRANSFER()
        {
            this.STOCK_TRANSFER_DETAIL = new List<STOCK_TRANSFER_DETAIL>();
        }

        public string ID { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string Ref_OrgNo { get; set; }
        public Nullable<int> RefType { get; set; }
        public string Department_ID { get; set; }
        public string Employee_ID { get; set; }
        public string FromStock_ID { get; set; }
        public string Sender_ID { get; set; }
        public string ToStock_ID { get; set; }
        public string Receiver_ID { get; set; }
        public string Branch_ID { get; set; }
        public string Contract_ID { get; set; }
        public string Currency_ID { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string Barcode { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> IsReview { get; set; }
        public string User_ID { get; set; }
        public Nullable<bool> IsClose { get; set; }
        public Nullable<long> Sorted { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<STOCK_TRANSFER_DETAIL> STOCK_TRANSFER_DETAIL { get; set; }
    }
}
