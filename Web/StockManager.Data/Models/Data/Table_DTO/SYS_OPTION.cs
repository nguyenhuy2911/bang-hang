using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class SYS_OPTION
    {
        public string Option_ID { get; set; }
        public string OptionValue { get; set; }
        public Nullable<int> ValueType { get; set; }
        public Nullable<bool> System { get; set; }
        public string Description { get; set; }
    }
}
