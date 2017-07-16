using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class STOCK_TRANSFER_DETAILMap : EntityTypeConfiguration<STOCK_TRANSFER_DETAIL>
    {
        public STOCK_TRANSFER_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Transfer_ID)
              //  .IsRequired()
                .HasMaxLength(20);

            //this.Property(t => t.Product_ID)
            //    .IsRequired();

            this.Property(t => t.Product_Name)
                .HasMaxLength(250);

            this.Property(t => t.OutStock)
                .HasMaxLength(20);

            this.Property(t => t.InStock)
                .HasMaxLength(20);

            this.Property(t => t.Unit)
                .HasMaxLength(20);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.Serial)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("STOCK_TRANSFER_DETAIL");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Transfer_ID).HasColumnName("Transfer_ID");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Product_Name).HasColumnName("Product_Name");
            this.Property(t => t.OutStock).HasColumnName("OutStock");
            this.Property(t => t.InStock).HasColumnName("InStock");
            this.Property(t => t.Lev1).HasColumnName("Lev1");
            this.Property(t => t.Lev2).HasColumnName("Lev2");
            this.Property(t => t.Lev3).HasColumnName("Lev3");
            this.Property(t => t.Lev4).HasColumnName("Lev4");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.UnitConvert).HasColumnName("UnitConvert");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.QtyConvert).HasColumnName("QtyConvert");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");

            // Relationships
            this.HasOptional(t => t.PRODUCT)
                .WithMany(t => t.STOCK_TRANSFER_DETAIL)
                .HasForeignKey(d => d.Product_ID);
            this.HasOptional(t => t.STOCK_TRANSFER)
                .WithMany(t => t.STOCK_TRANSFER_DETAIL)
                .HasForeignKey(d => d.Transfer_ID);

        }
    }
}
