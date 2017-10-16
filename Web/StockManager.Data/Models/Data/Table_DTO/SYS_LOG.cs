using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class SYS_LOG
    {
        public long SYS_ID { get; set; }
        public string MChine { get; set; }
        public string AccountWin { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Module { get; set; }
        public Nullable<int> Action { get; set; }
        public string Action_Name { get; set; }
        public string Reference { get; set; }
        public Nullable<System.DateTime> VoucherDate { get; set; }
        public string IPLan { get; set; }
        public string IPWan { get; set; }
        public string Mac { get; set; }
        public string DeviceName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
