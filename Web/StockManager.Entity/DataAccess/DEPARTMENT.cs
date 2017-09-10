using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class DEPARTMENT
    {
        public string Department_ID { get; set; }
        public string Department_Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
