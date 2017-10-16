using StockManager.Data.Model.Data;
using System.Data.Entity.ModelConfiguration;

namespace StockManager.Data.Models.Mapping
{
    public class UNITCONVERTMap : EntityTypeConfiguration<UNITCONVERT>
    {
        public UNITCONVERTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Product_ID, t.Unit_ID, t.UnitChild_ID });

            // Properties
            this.Property(t => t.Product_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Unit_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.UnitChild_ID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("UNITCONVERT");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Unit_ID).HasColumnName("Unit_ID");
            this.Property(t => t.UnitConvert1).HasColumnName("UnitConvert");
            this.Property(t => t.UnitChild_ID).HasColumnName("UnitChild_ID");
        }
    }
}
