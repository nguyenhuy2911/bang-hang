using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class PRODUCT_GROUP
    {
        public PRODUCT_GROUP()
        {
           
        }

        public int ProductGroup_ID { get; set; }
        public string ProductGroup_Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> IsMain { get; set; }
        public bool Active { get; set; }

    }
}
