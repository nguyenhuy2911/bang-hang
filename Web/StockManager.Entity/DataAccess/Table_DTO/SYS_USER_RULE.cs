using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class SYS_USER_RULE
    {
        public string Goup_ID { get; set; }
        public string Object_ID { get; set; }
        public string Rule_ID { get; set; }
        public Nullable<bool> AllowAdd { get; set; }
        public Nullable<bool> AllowDelete { get; set; }
        public Nullable<bool> AllowEdit { get; set; }
        public Nullable<bool> AllowAccess { get; set; }
        public Nullable<bool> AllowPrint { get; set; }
        public Nullable<bool> AllowExport { get; set; }
        public Nullable<bool> AllowImport { get; set; }
        public bool Active { get; set; }
        public virtual SYS_GROUP SYS_GROUP { get; set; }
        public virtual SYS_RULE SYS_RULE { get; set; }
    }
}
