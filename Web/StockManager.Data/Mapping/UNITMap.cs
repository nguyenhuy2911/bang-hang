using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class UNITMap : EntityTypeConfiguration<UNIT>
    {
        public UNITMap()
        {
            // Primary Key
            this.HasKey(t => t.Unit_ID);

            // Properties
            this.Property(t => t.Unit_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Unit_Name)
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("UNIT");
            this.Property(t => t.Unit_ID).HasColumnName("Unit_ID");
            this.Property(t => t.Unit_Name).HasColumnName("Unit_Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
