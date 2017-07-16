using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class PRODUCT_UNIT
    {
        public string Product_ID { get; set; }
        public string Unit_ID { get; set; }
        public string UnitConvert_ID { get; set; }
        public decimal UnitConvert { get; set; }
        public long Sorted { get; set; }
        public virtual UNIT UNIT { get; set; }
    }
}
