using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class DEPARTMENTMap : EntityTypeConfiguration<DEPARTMENT>
    {
        public DEPARTMENTMap()
        {
            // Primary Key
            this.HasKey(t => t.Department_ID);

            // Properties
            this.Property(t => t.Department_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Department_Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("DEPARTMENT");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.Department_Name).HasColumnName("Department_Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
