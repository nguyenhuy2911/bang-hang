using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class STOCKMap : EntityTypeConfiguration<STOCK>
    {
        public STOCKMap()
        {
            // Primary Key
            this.HasKey(t => t.Stock_ID);

            // Properties
            this.Property(t => t.Stock_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Stock_Name)
                .HasMaxLength(255);

            this.Property(t => t.Contact)
                .HasMaxLength(255);

            this.Property(t => t.Address)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Telephone)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Mobi)
                .HasMaxLength(20);

            this.Property(t => t.Manager)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("STOCK");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Stock_Name).HasColumnName("Stock_Name");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Mobi).HasColumnName("Mobi");
            this.Property(t => t.Manager).HasColumnName("Manager");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
