using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class UNIT
    {
        public UNIT()
        {
            this.PRODUCTs = new List<PRODUCT>();
            this.PRODUCT_UNIT = new List<PRODUCT_UNIT>();
        }

        public string Unit_ID { get; set; }
        public string Unit_Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }
        public virtual ICollection<PRODUCT_UNIT> PRODUCT_UNIT { get; set; }
    }
}
