using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class STOCK_BUILD_DETAILMap : EntityTypeConfiguration<STOCK_BUILD_DETAIL>
    {
        public STOCK_BUILD_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Build_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Product_ID)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ProductName)
                .HasMaxLength(255);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Unit)
                .HasMaxLength(20);

            this.Property(t => t.Serial)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("STOCK_BUILD_DETAIL");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Build_ID).HasColumnName("Build_ID");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.RefTypeSub).HasColumnName("RefTypeSub");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitConvert).HasColumnName("UnitConvert");
            this.Property(t => t.Vat).HasColumnName("Vat");
            this.Property(t => t.CurrentQty).HasColumnName("CurrentQty");
            this.Property(t => t.QuantityDefault).HasColumnName("QuantityDefault");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.QtyConvert).HasColumnName("QtyConvert");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Charge).HasColumnName("Charge");
            this.Property(t => t.Limit).HasColumnName("Limit");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");

            // Relationships
            this.HasRequired(t => t.STOCK_BUILD)
                .WithMany(t => t.STOCK_BUILD_DETAIL)
                .HasForeignKey(d => d.Build_ID);

        }
    }
}
