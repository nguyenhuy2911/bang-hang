using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class PRODUCT_BUILDMap : EntityTypeConfiguration<PRODUCT_BUILD>
    {
        public PRODUCT_BUILDMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ProductID, t.BuildID });

            // Properties
            this.Property(t => t.ProductID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.BuildID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("PRODUCT_BUILD");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.BuildID).HasColumnName("BuildID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Amount).HasColumnName("Amount");
        }
    }
}
