using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class REFTYPE
    {
        public short ID { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public Nullable<short> CategoryID { get; set; }
        public Nullable<long> Sorted { get; set; }
        public Nullable<bool> IsSearch { get; set; }
    }
}
