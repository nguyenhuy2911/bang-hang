using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class PRODUCT_PRICEMap : EntityTypeConfiguration<PRODUCT_PRICE>
    {
        public PRODUCT_PRICEMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(20);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(20);

            this.Property(t => t.OwnerID)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PRODUCT_PRICE");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.RefStatus).HasColumnName("RefStatus");
            this.Property(t => t.BeginDate).HasColumnName("BeginDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.DiscountRate).HasColumnName("DiscountRate");
            this.Property(t => t.CommissionRate).HasColumnName("CommissionRate");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.BeginAmount).HasColumnName("BeginAmount");
            this.Property(t => t.EndAmount).HasColumnName("EndAmount");
            this.Property(t => t.IsPublic).HasColumnName("IsPublic");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.OwnerID).HasColumnName("OwnerID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Active).HasColumnName("Active");
        }
    }
}
