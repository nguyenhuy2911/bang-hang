using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class SYS_GROUPMap : EntityTypeConfiguration<SYS_GROUP>
    {
        public SYS_GROUPMap()
        {
            // Primary Key
            this.HasKey(t => t.Group_ID);

            // Properties
            this.Property(t => t.Group_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Group_Name)
                .HasMaxLength(100);

            this.Property(t => t.Group_NameEn)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("SYS_GROUP");
            this.Property(t => t.Group_ID).HasColumnName("Group_ID");
            this.Property(t => t.Group_Name).HasColumnName("Group_Name");
            this.Property(t => t.Group_NameEn).HasColumnName("Group_NameEn");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
