using StockManager.Entity.DataAccess;
using System.Data.Entity.ModelConfiguration;

namespace StockManager.Data.Models.Mapping
{
    public class TRANS_REFMap : EntityTypeConfiguration<TRANS_REF>
    {
        public TRANS_REFMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.RefID)
                .HasMaxLength(20);

            this.Property(t => t.RefOrgNo)
                .HasMaxLength(20);

            this.Property(t => t.TransFrom)
                .HasMaxLength(20);

            this.Property(t => t.TransTo)
                .HasMaxLength(50);

            this.Property(t => t.Department_ID)
                .HasMaxLength(50);

            this.Property(t => t.Employee_ID)
                .HasMaxLength(50);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(50);

            this.Property(t => t.Branch_ID)
                .HasMaxLength(50);

            this.Property(t => t.Contract_ID)
                .HasMaxLength(50);

            this.Property(t => t.Contract)
                .HasMaxLength(200);

            this.Property(t => t.Reason)
                .HasMaxLength(255);

            this.Property(t => t.Currency_ID)
                .HasMaxLength(3);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.User_ID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TRANS_REF");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefID).HasColumnName("RefID");
            this.Property(t => t.RefOrgNo).HasColumnName("RefOrgNo");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.TransFrom).HasColumnName("TransFrom");
            this.Property(t => t.TransTo).HasColumnName("TransTo");
            this.Property(t => t.Department_ID).HasColumnName("Department_ID");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Branch_ID).HasColumnName("Branch_ID");
            this.Property(t => t.Contract_ID).HasColumnName("Contract_ID");
            this.Property(t => t.Contract).HasColumnName("Contract");
            this.Property(t => t.Reason).HasColumnName("Reason");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.FAmount).HasColumnName("FAmount");
            this.Property(t => t.FDiscount).HasColumnName("FDiscount");
            this.Property(t => t.IsClose).HasColumnName("IsClose");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
