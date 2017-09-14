using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class ProductAttributeMap : EntityTypeConfiguration<ProductAttribute>
    {
        public ProductAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Value)
                .HasMaxLength(250);

            this.Property(t => t.Image)
                .HasMaxLength(250);

            this.Property(t => t.Type)
                .HasMaxLength(50);

            this.Property(t => t.TypeName)
               .HasMaxLength(250);           

            // Table & Column Mappings
            this.ToTable("ProductAttribute");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");         

            // Relationships
        }
    }
}
