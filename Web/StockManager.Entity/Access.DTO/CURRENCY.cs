using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class CURRENCY
    {
        public string Currency_ID { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<decimal> Exchange { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
