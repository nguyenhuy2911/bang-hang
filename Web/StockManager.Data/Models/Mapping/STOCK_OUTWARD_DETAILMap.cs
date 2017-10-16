using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Data.Model.Data;
namespace StockManager.Data.Models.Mapping
{
    public class STOCK_OUTWARD_DETAILMap : EntityTypeConfiguration<STOCK_OUTWARD_DETAIL>
    {
        public STOCK_OUTWARD_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Outward_ID)
               // .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            //this.Property(t => t.Product_ID)
            //    .IsRequired();

            this.Property(t => t.ProductName)
                .HasMaxLength(255);

            this.Property(t => t.Unit)
                .HasMaxLength(20);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.Serial)
                .HasMaxLength(50);

            this.Property(t => t.ChassyNo)
                .HasMaxLength(50);

            this.Property(t => t.IME)
                .HasMaxLength(50);

            this.Property(t => t.Orgin)
                .HasMaxLength(255);

            this.Property(t => t.Size)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("STOCK_OUTWARD_DETAIL");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Outward_ID).HasColumnName("Outward_ID");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.Vat).HasColumnName("Vat");
            this.Property(t => t.Lev1).HasColumnName("Lev1");
            this.Property(t => t.Lev2).HasColumnName("Lev2");
            this.Property(t => t.Lev3).HasColumnName("Lev3");
            this.Property(t => t.Lev4).HasColumnName("Lev4");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitConvert).HasColumnName("UnitConvert");
            this.Property(t => t.CurrentQty).HasColumnName("CurrentQty");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.QtyConvert).HasColumnName("QtyConvert");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Charge).HasColumnName("Charge");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Profit).HasColumnName("Profit");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.ChassyNo).HasColumnName("ChassyNo");
            this.Property(t => t.IME).HasColumnName("IME");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Orgin).HasColumnName("Orgin");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasOptional(t => t.PRODUCT)
                .WithMany(t => t.STOCK_OUTWARD_DETAIL)
                .HasForeignKey(d => d.Product_ID);
            this.HasOptional(t => t.STOCK_OUTWARD)
                .WithMany(t => t.STOCK_OUTWARD_DETAIL)
                .HasForeignKey(d => d.Outward_ID);

        }
    }
}
