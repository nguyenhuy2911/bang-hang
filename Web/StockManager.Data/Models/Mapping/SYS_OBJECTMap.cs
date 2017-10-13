using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class SYS_OBJECTMap : EntityTypeConfiguration<SYS_OBJECT>
    {
        public SYS_OBJECTMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Object_ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Object_Name)
                .HasMaxLength(50);

            this.Property(t => t.Object_NameEn)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Parent_ID)
                .HasMaxLength(20);

            this.Property(t => t.Owner)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SYS_OBJECT");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Object_ID).HasColumnName("Object_ID");
            this.Property(t => t.Object_Name).HasColumnName("Object_Name");
            this.Property(t => t.Object_NameEn).HasColumnName("Object_NameEn");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Parent_ID).HasColumnName("Parent_ID");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.Order_ID).HasColumnName("Order_ID");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
