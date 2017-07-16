using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class PRODUCT_GROUP
    {
        public PRODUCT_GROUP()
        {
            this.PRODUCTs = new List<PRODUCT>();
        }

        public string ProductGroup_ID { get; set; }
        public string ProductGroup_Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsMain { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }
    }
}
