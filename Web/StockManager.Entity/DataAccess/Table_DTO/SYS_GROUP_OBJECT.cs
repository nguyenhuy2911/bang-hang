using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class SYS_GROUP_OBJECT
    {
        public string Object_ID { get; set; }
        public string Goup_ID { get; set; }
        public string Active { get; set; }
        public virtual SYS_GROUP SYS_GROUP { get; set; }
    }
}
