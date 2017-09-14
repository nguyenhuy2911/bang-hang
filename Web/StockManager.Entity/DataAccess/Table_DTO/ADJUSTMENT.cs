using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class ADJUSTMENT
    {
        public ADJUSTMENT()
        {
            this.ADJUSTMENT_DETAIL = new List<ADJUSTMENT_DETAIL>();
        }

        public string ID { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string Ref_OrgNo { get; set; }
        public Nullable<int> RefType { get; set; }
        public string Employee_ID { get; set; }
        public string Stock_ID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> Accept { get; set; }
        public Nullable<bool> IsClose { get; set; }
        public string Description { get; set; }
        public string User_ID { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<ADJUSTMENT_DETAIL> ADJUSTMENT_DETAIL { get; set; }
    }
}
