using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class SYS_INFO
    {
        public string SysInfo_ID { get; set; }
        public string Application { get; set; }
        public string Version { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Description { get; set; }
        public Nullable<int> Interface { get; set; }
        public string Guid_ID { get; set; }
    }
}
