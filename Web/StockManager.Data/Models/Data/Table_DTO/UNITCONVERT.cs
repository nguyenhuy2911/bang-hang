using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class UNITCONVERT
    {
        public string Product_ID { get; set; }
        public string Unit_ID { get; set; }
        public Nullable<decimal> UnitConvert1 { get; set; }
        public string UnitChild_ID { get; set; }
    }
}
