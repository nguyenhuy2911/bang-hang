using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class SYS_USER
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Group_ID { get; set; }
        public string Description { get; set; }
        public string PartID { get; set; }
        public bool Active { get; set; }
        public virtual SYS_GROUP SYS_GROUP { get; set; }
    }
}
