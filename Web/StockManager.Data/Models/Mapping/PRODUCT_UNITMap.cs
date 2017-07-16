using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class PRODUCT_UNITMap : EntityTypeConfiguration<PRODUCT_UNIT>
    {
        public PRODUCT_UNITMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Product_ID, t.Unit_ID, t.UnitConvert_ID });

            // Properties
            this.Property(t => t.Product_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Unit_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.UnitConvert_ID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("PRODUCT_UNIT");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Unit_ID).HasColumnName("Unit_ID");
            this.Property(t => t.UnitConvert_ID).HasColumnName("UnitConvert_ID");
            this.Property(t => t.UnitConvert).HasColumnName("UnitConvert");
            this.Property(t => t.Sorted).HasColumnName("Sorted");

            // Relationships
            this.HasRequired(t => t.UNIT)
                .WithMany(t => t.PRODUCT_UNIT)
                .HasForeignKey(d => d.Unit_ID);

        }
    }
}
