using StockManager.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StockManager.Data.Models.Mapping
{
    public class ADJUSTMENT_DETAILMap : EntityTypeConfiguration<ADJUSTMENT_DETAIL>
    {
        public ADJUSTMENT_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adjustment_ID)
              //  .IsRequired()
                .HasMaxLength(20);

            //this.Property(t => t.Product_ID)
            //    .IsRequired();

            this.Property(t => t.Product_Name)
                .HasMaxLength(255);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Unit)
                .HasMaxLength(20);

            this.Property(t => t.Orgin)
                .HasMaxLength(255);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.Serial)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ADJUSTMENT_DETAIL");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adjustment_ID).HasColumnName("Adjustment_ID");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Product_Name).HasColumnName("Product_Name");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitConvert).HasColumnName("UnitConvert");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Orgin).HasColumnName("Orgin");
            this.Property(t => t.CurrentQty).HasColumnName("CurrentQty");
            this.Property(t => t.NewQty).HasColumnName("NewQty");
            this.Property(t => t.QtyDiff).HasColumnName("QtyDiff");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.QtyConvert).HasColumnName("QtyConvert");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");

            // Relationships
            this.HasOptional(t => t.ADJUSTMENT)
                .WithMany(t => t.ADJUSTMENT_DETAIL)
                .HasForeignKey(d => d.Adjustment_ID);
            this.HasOptional(t => t.PRODUCT)
                .WithMany(t => t.ADJUSTMENT_DETAIL)
                .HasForeignKey(d => d.Product_ID);

        }
    }
}
