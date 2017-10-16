using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class SYS_GROUP_OBJECTMap : EntityTypeConfiguration<SYS_GROUP_OBJECT>
    {
        public SYS_GROUP_OBJECTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Object_ID, t.Goup_ID });

            // Properties
            this.Property(t => t.Object_ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Goup_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Active)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("SYS_GROUP_OBJECT");
            this.Property(t => t.Object_ID).HasColumnName("Object_ID");
            this.Property(t => t.Goup_ID).HasColumnName("Goup_ID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.SYS_GROUP)
                .WithMany(t => t.SYS_GROUP_OBJECT)
                .HasForeignKey(d => d.Goup_ID);

        }
    }
}
