using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class SYS_RULE
    {
        public SYS_RULE()
        {
            this.SYS_USER_RULE = new List<SYS_USER_RULE>();
        }

        public string Rule_ID { get; set; }
        public string Rule_Name { get; set; }
        public string Rule_NameEn { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<SYS_USER_RULE> SYS_USER_RULE { get; set; }
    }
}
