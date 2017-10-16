using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;

namespace StockManager.Data.Models.Mapping
{
    public class SYS_RULEMap : EntityTypeConfiguration<SYS_RULE>
    {
        public SYS_RULEMap()
        {
            // Primary Key
            this.HasKey(t => t.Rule_ID);

            // Properties
            this.Property(t => t.Rule_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Rule_Name)
                .HasMaxLength(100);

            this.Property(t => t.Rule_NameEn)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("SYS_RULE");
            this.Property(t => t.Rule_ID).HasColumnName("Rule_ID");
            this.Property(t => t.Rule_Name).HasColumnName("Rule_Name");
            this.Property(t => t.Rule_NameEn).HasColumnName("Rule_NameEn");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
