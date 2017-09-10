using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;

namespace StockManager.Data.Models.Mapping
{
    public class SYS_USER_RULEMap : EntityTypeConfiguration<SYS_USER_RULE>
    {
        public SYS_USER_RULEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Goup_ID, t.Object_ID });

            // Properties
            this.Property(t => t.Goup_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Object_ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Rule_ID)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("SYS_USER_RULE");
            this.Property(t => t.Goup_ID).HasColumnName("Goup_ID");
            this.Property(t => t.Object_ID).HasColumnName("Object_ID");
            this.Property(t => t.Rule_ID).HasColumnName("Rule_ID");
            this.Property(t => t.AllowAdd).HasColumnName("AllowAdd");
            this.Property(t => t.AllowDelete).HasColumnName("AllowDelete");
            this.Property(t => t.AllowEdit).HasColumnName("AllowEdit");
            this.Property(t => t.AllowAccess).HasColumnName("AllowAccess");
            this.Property(t => t.AllowPrint).HasColumnName("AllowPrint");
            this.Property(t => t.AllowExport).HasColumnName("AllowExport");
            this.Property(t => t.AllowImport).HasColumnName("AllowImport");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.SYS_GROUP)
                .WithMany(t => t.SYS_USER_RULE)
                .HasForeignKey(d => d.Goup_ID);
            this.HasRequired(t => t.SYS_RULE)
                .WithMany(t => t.SYS_USER_RULE)
                .HasForeignKey(d => d.Rule_ID);

        }
    }
}
