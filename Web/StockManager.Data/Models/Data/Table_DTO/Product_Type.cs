using System;
using System.Collections.Generic;

namespace StockManager.Data.Model.Data
{
    public partial class Product_Type
    {
        public Product_Type()
        {
            this.ProductType_Attributes = new List<ProductType_Attribute>();
        }
        public int Product_Type_ID { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<ProductType_Attribute> ProductType_Attributes { get; set; }
    }
}
