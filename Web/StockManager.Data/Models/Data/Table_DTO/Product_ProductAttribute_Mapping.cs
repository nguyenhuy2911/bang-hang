using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManager.Data.Model.Data
{


    [Table("Product_ProductAttribute_Mapping")]
    public partial class Product_ProductAttribute_Mapping
    {
        [Key]
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? ProductAttributeId { get; set; }

        public string TextPrompt { get; set; }

        public bool? IsRequired { get; set; }

        public int? AttributeControlTypeId { get; set; }

        public int? DisplayOrder { get; set; }

        public int? ValidationMinLength { get; set; }

        public int? ValidationMaxLength { get; set; }

        public string ValidationFileAllowedExtensions { get; set; }

        public int? ValidationFileMaximumSize { get; set; }

        public string DefaultValue { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }

        [ForeignKey("ProductId")]
        public virtual PRODUCT PRODUCT { get; set; }

        [ForeignKey("ProductAttributeId")]
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
