using StockManager.Data.Model.Data;
using System.Data.Entity.ModelConfiguration;
namespace StockManager.Data.Models.Mapping
{
    public class Product_TypeMap : EntityTypeConfiguration<Product_Type>
    {
        public Product_TypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Product_Type_ID);

            this.Property(t => t.Product_Type_ID)
                .IsRequired();

            this.Property(t => t.Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PRODUCT_TYPE");
            this.Property(t => t.Product_Type_ID).HasColumnName("Product_Type_ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
        }
    }
}
