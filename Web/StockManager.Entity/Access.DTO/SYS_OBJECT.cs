using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class SYS_OBJECT
    {
        public System.Guid ID { get; set; }
        public string Object_ID { get; set; }
        public string Object_Name { get; set; }
        public string Object_NameEn { get; set; }
        public string Description { get; set; }
        public string Parent_ID { get; set; }
        public Nullable<int> Level { get; set; }
        public Nullable<int> Order_ID { get; set; }
        public string Owner { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
