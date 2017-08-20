using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class PRODUCT_GROUPMap : EntityTypeConfiguration<PRODUCT_GROUP>
    {
        public PRODUCT_GROUPMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductGroup_ID);

            // Properties
            this.Property(t => t.ProductGroup_Name)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PRODUCT_GROUP");
            this.Property(t => t.ProductGroup_ID).HasColumnName("ProductGroup_ID");
            this.Property(t => t.ProductGroup_Name).HasColumnName("ProductGroup_Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsMain).HasColumnName("IsMain");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
