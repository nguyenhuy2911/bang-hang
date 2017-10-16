using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class ADJUSTMENTMap : EntityTypeConfiguration<ADJUSTMENT>
    {
        public ADJUSTMENTMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Ref_OrgNo)
                .HasMaxLength(20);

            this.Property(t => t.Employee_ID)
                .HasMaxLength(20);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.User_ID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ADJUSTMENT");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.Ref_OrgNo).HasColumnName("Ref_OrgNo");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Accept).HasColumnName("Accept");
            this.Property(t => t.IsClose).HasColumnName("IsClose");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
