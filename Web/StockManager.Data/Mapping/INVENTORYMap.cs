using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class INVENTORYMap : EntityTypeConfiguration<INVENTORY>
    {
        public INVENTORYMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RefID)
                .HasMaxLength(20);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Product_ID)
                .HasMaxLength(20);

            this.Property(t => t.Customer_ID)
                .HasMaxLength(20);

            this.Property(t => t.Currency_ID)
                .HasMaxLength(3);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.Serial)
                .HasMaxLength(50);

            this.Property(t => t.ChassyNo)
                .HasMaxLength(50);

            this.Property(t => t.Color)
                .HasMaxLength(20);

            this.Property(t => t.Location)
                .HasMaxLength(20);

            this.Property(t => t.Orgin)
                .HasMaxLength(255);

            this.Property(t => t.Size)
                .HasMaxLength(255);

            this.Property(t => t.Descritopn)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("INVENTORY");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefID).HasColumnName("RefID");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Customer_ID).HasColumnName("Customer_ID");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.Limit).HasColumnName("Limit");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.ChassyNo).HasColumnName("ChassyNo");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Orgin).HasColumnName("Orgin");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.Descritopn).HasColumnName("Descritopn");
        }
    }
}
