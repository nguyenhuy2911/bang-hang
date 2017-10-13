using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;

namespace StockManager.Data.Models.Mapping
{
    public class SYS_USERMap : EntityTypeConfiguration<SYS_USER>
    {
        public SYS_USERMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.Group_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.PartID)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SYS_USER");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Group_ID).HasColumnName("Group_ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasRequired(t => t.SYS_GROUP)
                .WithMany(t => t.SYS_USER)
                .HasForeignKey(d => d.Group_ID);

        }
    }
}
