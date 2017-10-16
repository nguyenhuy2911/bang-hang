namespace StockManager.Data.Model.Data
{


    public partial class Product_ProductAttribute_Mapping
    {
        public int Id { get; set; }

        public  int? ProductId { get; set; }  

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
        public string Type { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
