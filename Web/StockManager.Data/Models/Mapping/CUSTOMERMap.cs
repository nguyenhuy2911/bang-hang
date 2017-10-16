using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class CUSTOMERMap : EntityTypeConfiguration<CUSTOMER>
    {
        public CUSTOMERMap()
        {
            // Primary Key
            this.HasKey(t => t.Customer_ID);

            // Properties
            this.Property(t => t.Customer_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustomerName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Customer_Type_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Customer_Group_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.CustomerAddress)
                .HasMaxLength(255);

            this.Property(t => t.Birthday)
                .HasMaxLength(10);

            this.Property(t => t.Barcode)
                .HasMaxLength(20);

            this.Property(t => t.Tax)
                .HasMaxLength(20);

            this.Property(t => t.Tel)
                .HasMaxLength(20);

            this.Property(t => t.Fax)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Mobile)
                .HasMaxLength(20);

            this.Property(t => t.Website)
                .HasMaxLength(100);

            this.Property(t => t.Contact)
                .HasMaxLength(100);

            this.Property(t => t.Position)
                .HasMaxLength(100);

            this.Property(t => t.NickYM)
                .HasMaxLength(20);

            this.Property(t => t.NickSky)
                .HasMaxLength(20);

            this.Property(t => t.Area)
                .HasMaxLength(100);

            this.Property(t => t.District)
                .HasMaxLength(100);

            this.Property(t => t.Contry)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.BankAccount)
                .HasMaxLength(20);

            this.Property(t => t.BankName)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("CUSTOMER");
            this.Property(t => t.Customer_ID).HasColumnName("Customer_ID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.Customer_Type_ID).HasColumnName("Customer_Type_ID");
            this.Property(t => t.Customer_Group_ID).HasColumnName("Customer_Group_ID");
            this.Property(t => t.CustomerAddress).HasColumnName("CustomerAddress");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.Tax).HasColumnName("Tax");
            this.Property(t => t.Tel).HasColumnName("Tel");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.NickYM).HasColumnName("NickYM");
            this.Property(t => t.NickSky).HasColumnName("NickSky");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.Contry).HasColumnName("Contry");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.BankAccount).HasColumnName("BankAccount");
            this.Property(t => t.BankName).HasColumnName("BankName");
            this.Property(t => t.CreditLimit).HasColumnName("CreditLimit");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.IsDebt).HasColumnName("IsDebt");
            this.Property(t => t.IsDebtDetail).HasColumnName("IsDebtDetail");
            this.Property(t => t.IsProvider).HasColumnName("IsProvider");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
