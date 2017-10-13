using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;

namespace StockManager.Data.Models.Mapping
{
    public class SYS_OPTIONMap : EntityTypeConfiguration<SYS_OPTION>
    {
        public SYS_OPTIONMap()
        {
            // Primary Key
            this.HasKey(t => t.Option_ID);

            // Properties
            this.Property(t => t.Option_ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OptionValue)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("SYS_OPTION");
            this.Property(t => t.Option_ID).HasColumnName("Option_ID");
            this.Property(t => t.OptionValue).HasColumnName("OptionValue");
            this.Property(t => t.ValueType).HasColumnName("ValueType");
            this.Property(t => t.System).HasColumnName("System");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
