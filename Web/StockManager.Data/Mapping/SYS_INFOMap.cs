using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class SYS_INFOMap : EntityTypeConfiguration<SYS_INFO>
    {
        public SYS_INFOMap()
        {
            // Primary Key
            this.HasKey(t => t.SysInfo_ID);

            // Properties
            this.Property(t => t.SysInfo_ID)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Application)
                .HasMaxLength(50);

            this.Property(t => t.Version)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Guid_ID)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("SYS_INFO");
            this.Property(t => t.SysInfo_ID).HasColumnName("SysInfo_ID");
            this.Property(t => t.Application).HasColumnName("Application");
            this.Property(t => t.Version).HasColumnName("Version");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Interface).HasColumnName("Interface");
            this.Property(t => t.Guid_ID).HasColumnName("Guid_ID");
        }
    }
}
