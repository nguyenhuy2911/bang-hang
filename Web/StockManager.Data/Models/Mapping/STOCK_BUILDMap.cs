using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class STOCK_BUILDMap : EntityTypeConfiguration<STOCK_BUILD>
    {
        public STOCK_BUILDMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Ref_OrgNo)
                .HasMaxLength(20);

            this.Property(t => t.Barcode)
                .HasMaxLength(20);

            this.Property(t => t.Department_ID)
                .HasMaxLength(20);

            this.Property(t => t.Employee_ID)
                .HasMaxLength(20);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            this.Property(t => t.Reason)
                .HasMaxLength(255);

            this.Property(t => t.Currency_ID)
                .HasMaxLength(3);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.User_ID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("STOCK_BUILD");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.Ref_OrgNo).HasColumnName("Ref_OrgNo");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.Vat).HasColumnName("Vat");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.FAmount).HasColumnName("FAmount");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Charge).HasColumnName("Charge");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
        }
    }
}
