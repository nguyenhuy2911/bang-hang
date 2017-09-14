using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class CUSTOMER_TYPE
    {
        public string Customer_Type_ID { get; set; }
        public string Customer_Type_Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
