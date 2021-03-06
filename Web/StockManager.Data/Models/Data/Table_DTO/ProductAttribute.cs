using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockManager.Data.Model.Data
{
    public partial class ProductAttribute
    {

        public ProductAttribute()
        {
            Product_ProductAttribute_Mapping = new List<Product_ProductAttribute_Mapping>();
            ProductType_Attributes = new List<ProductType_Attribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Product_ProductAttribute_Mapping> Product_ProductAttribute_Mapping { get; set; }
        public virtual ICollection<ProductType_Attribute> ProductType_Attributes { get; set; }
    }
}
