using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class CUSTOMER_TYPEMap : EntityTypeConfiguration<CUSTOMER_TYPE>
    {
        public CUSTOMER_TYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.Customer_Type_ID);

            // Properties
            this.Property(t => t.Customer_Type_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Customer_Type_Name)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CUSTOMER_TYPE");
            this.Property(t => t.Customer_Type_ID).HasColumnName("Customer_Type_ID");
            this.Property(t => t.Customer_Type_Name).HasColumnName("Customer_Type_Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
