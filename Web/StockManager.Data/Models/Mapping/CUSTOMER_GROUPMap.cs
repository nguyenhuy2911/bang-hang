using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class CUSTOMER_GROUPMap : EntityTypeConfiguration<CUSTOMER_GROUP>
    {
        public CUSTOMER_GROUPMap()
        {
            // Primary Key
            this.HasKey(t => t.Customer_Group_ID);

            // Properties
            this.Property(t => t.Customer_Group_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Customer_Group_Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CUSTOMER_GROUP");
            this.Property(t => t.Customer_Group_ID).HasColumnName("Customer_Group_ID");
            this.Property(t => t.Customer_Group_Name).HasColumnName("Customer_Group_Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
