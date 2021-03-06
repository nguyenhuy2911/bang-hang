namespace StockManager.Entity.Service.Contract
{ 
    public class Product_ProductAttribute_Mapping_DTO
    {
        public Product_ProductAttribute_Mapping_DTO()
        {
           
        }
            
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductAttributeId { get; set; }

        public string TextPrompt { get; set; }

        public bool IsRequired { get; set; }

        public int AttributeControlTypeId { get; set; }

        public int DisplayOrder { get; set; }

        public int? ValidationMinLength { get; set; }

        public int ValidationMaxLength { get; set; }

        public string ValidationFileAllowedExtensions { get; set; }

        public int ValidationFileMaximumSize { get; set; }

        public string DefaultValue { get; set; }
        public string Type { get; set; }

        public ProductAttribute_DTO ProductAttribute { get; set; }
    }
}
