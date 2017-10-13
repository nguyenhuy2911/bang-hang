using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class STOCK_TRANSFERMap : EntityTypeConfiguration<STOCK_TRANSFER>
    {
        public STOCK_TRANSFERMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Ref_OrgNo)
                .HasMaxLength(20);

            this.Property(t => t.Department_ID)
                .HasMaxLength(20);

            this.Property(t => t.Employee_ID)
                .HasMaxLength(20);

            this.Property(t => t.FromStock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Sender_ID)
                .HasMaxLength(20);

            this.Property(t => t.ToStock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Receiver_ID)
                .HasMaxLength(20);

            this.Property(t => t.Branch_ID)
                .HasMaxLength(20);

            this.Property(t => t.Contract_ID)
                .HasMaxLength(20);

            this.Property(t => t.Currency_ID)
                .HasMaxLength(3);

            this.Property(t => t.Barcode)
                .HasMaxLength(20);

            this.Property(t => t.User_ID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("STOCK_TRANSFER");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.Ref_OrgNo).HasColumnName("Ref_OrgNo");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.FromStock_ID).HasColumnName("FromStock_ID");
            this.Property(t => t.Sender_ID).HasColumnName("Sender_ID");
            this.Property(t => t.ToStock_ID).HasColumnName("ToStock_ID");
            this.Property(t => t.Receiver_ID).HasColumnName("Receiver_ID");
            this.Property(t => t.Branch_ID).HasColumnName("Branch_ID");
            this.Property(t => t.Contract_ID).HasColumnName("Contract_ID");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.IsReview).HasColumnName("IsReview");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.IsClose).HasColumnName("IsClose");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
