using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class SYS_GROUP
    {
        public SYS_GROUP()
        {
            this.SYS_GROUP_OBJECT = new List<SYS_GROUP_OBJECT>();
            this.SYS_USER_RULE = new List<SYS_USER_RULE>();
            this.SYS_USER = new List<SYS_USER>();
        }

        public string Group_ID { get; set; }
        public string Group_Name { get; set; }
        public string Group_NameEn { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public virtual ICollection<SYS_GROUP_OBJECT> SYS_GROUP_OBJECT { get; set; }
        public virtual ICollection<SYS_USER_RULE> SYS_USER_RULE { get; set; }
        public virtual ICollection<SYS_USER> SYS_USER { get; set; }
    }
}
