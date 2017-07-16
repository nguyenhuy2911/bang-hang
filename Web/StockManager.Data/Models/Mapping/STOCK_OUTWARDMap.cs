using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class STOCK_OUTWARDMap : EntityTypeConfiguration<STOCK_OUTWARD>
    {
        public STOCK_OUTWARDMap()
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

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Branch_ID)
                .HasMaxLength(20);

            this.Property(t => t.Contract_ID)
                .HasMaxLength(20);

            this.Property(t => t.Customer_ID)
                .HasMaxLength(20);

            this.Property(t => t.CustomerName)
                .HasMaxLength(255);

            this.Property(t => t.CustomerAddress)
                .HasMaxLength(255);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            this.Property(t => t.Reason)
                .HasMaxLength(255);

            this.Property(t => t.Currency_ID)
                .HasMaxLength(3);

            this.Property(t => t.User_ID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("STOCK_OUTWARD");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.Ref_OrgNo).HasColumnName("Ref_OrgNo");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Branch_ID).HasColumnName("Branch_ID");
            this.Property(t => t.Contract_ID).HasColumnName("Contract_ID");
            this.Property(t => t.Customer_ID).HasColumnName("Customer_ID");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.CustomerAddress).HasColumnName("CustomerAddress");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.Payment).HasColumnName("Payment");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.FAmount).HasColumnName("FAmount");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Charge).HasColumnName("Charge");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Profit).HasColumnName("Profit");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.IsClose).HasColumnName("IsClose");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
