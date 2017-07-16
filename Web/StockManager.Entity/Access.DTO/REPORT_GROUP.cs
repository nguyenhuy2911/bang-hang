using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class REPORT_GROUP
    {
        public string Report_Group_ID { get; set; }
        public string Report_Group_Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
