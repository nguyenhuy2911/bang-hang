using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class BOOKMap : EntityTypeConfiguration<BOOK>
    {
        public BOOKMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.BookName)
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(20);

            this.Property(t => t.OwnerID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("BOOK");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.BookName).HasColumnName("BookName");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Closed).HasColumnName("Closed");
            this.Property(t => t.IsPublic).HasColumnName("IsPublic");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.OwnerID).HasColumnName("OwnerID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
