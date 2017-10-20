using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class Product_ProductAttribute_Mapping_Map : EntityTypeConfiguration<Product_ProductAttribute_Mapping>
    {
        public Product_ProductAttribute_Mapping_Map()
        {
            // Primary Key
            this.HasKey(t => t.Id);

          //  Properties
            //this.Property(t => t.ProductId)
            //    .IsRequired();

            //this.Property(t => t.ProductAttributeId)
            //    .IsRequired();

            this.Property(t => t.Type)
                .HasMaxLength(50);
            // Table & Column Mappings
            this.ToTable("Product_ProductAttribute_Mapping");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductAttributeId).HasColumnName("ProductAttributeId");
            this.Property(t => t.TextPrompt).HasColumnName("TextPrompt");
            this.Property(t => t.IsRequired).HasColumnName("IsRequired");
            this.Property(t => t.AttributeControlTypeId).HasColumnName("AttributeControlTypeId");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.ValidationMinLength).HasColumnName("ValidationMinLength");
            this.Property(t => t.ValidationMaxLength).HasColumnName("ValidationMaxLength");
            this.Property(t => t.ValidationFileAllowedExtensions).HasColumnName("ValidationFileAllowedExtensions");
            this.Property(t => t.ValidationFileMaximumSize).HasColumnName("ValidationFileMaximumSize");
            this.Property(t => t.DefaultValue).HasColumnName("DefaultValue");

            // Relationships
            this.HasOptional(t => t.PRODUCT)
                .WithMany(t => t.Product_ProductAttribute_Mapping)
                .HasForeignKey(d => d.ProductId);
            this.HasOptional(t => t.ProductAttribute)
                .WithMany(t => t.Product_ProductAttribute_Mapping)
                .HasForeignKey(d => d.ProductAttributeId);
        }
    }
}
