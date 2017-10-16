using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class INVENTORY
    {
        public INVENTORY()
        {
            this.INVENTORY_DETAIL = new List<INVENTORY_DETAIL>();
        }

        public long ID { get; set; }
        public string RefID { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public Nullable<int> RefType { get; set; }
        public string Stock_ID { get; set; }
        public string Product_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Currency_ID { get; set; }
        public Nullable<System.DateTime> Limit { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Batch { get; set; }
        public string Serial { get; set; }
        public string ChassyNo { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public string Orgin { get; set; }
        public string Size { get; set; }
        public string Descritopn { get; set; }
        public virtual ICollection<INVENTORY_DETAIL> INVENTORY_DETAIL { get; set; }
    }
}
