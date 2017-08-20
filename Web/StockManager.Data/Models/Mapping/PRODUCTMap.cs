using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
namespace StockManager.Data.Models.Mapping
{
    public class PRODUCTMap : EntityTypeConfiguration<PRODUCT>
    {
        public PRODUCTMap()
        {
            // Primary Key
            this.HasKey(t => t.Product_ID);

            // Properties
            this.Property(t => t.Product_ID)
                .IsRequired();

            this.Property(t => t.Product_Name)
                .HasMaxLength(255);

            this.Property(t => t.Product_NameEN)
                .HasMaxLength(255);

            this.Property(t => t.Model_ID)
                .HasMaxLength(20);

            //this.Property(t => t.Product_Group_ID)
            //    .HasMaxLength(20);

            this.Property(t => t.Provider_ID)
                .HasMaxLength(20);

            this.Property(t => t.Origin)
                .HasMaxLength(100);

            this.Property(t => t.Barcode)
                .HasMaxLength(20);

            this.Property(t => t.Unit_ID)
                .HasMaxLength(20);

            this.Property(t => t.UnitConvert)
                .HasMaxLength(20);

            this.Property(t => t.Customer_ID)
                .HasMaxLength(20);

            this.Property(t => t.Customer_Name)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Color)
                .HasMaxLength(50);

            this.Property(t => t.Size)
                .HasMaxLength(50);

            this.Property(t => t.Currency_ID)
                .HasMaxLength(3);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.UserID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("PRODUCT");
            this.Property(t => t.Product_ID).HasColumnName("ID");
            this.Property(t => t.Product_Name).HasColumnName("Product_Name");
            this.Property(t => t.Product_NameEN).HasColumnName("Product_NameEN");
            this.Property(t => t.Product_Type_ID).HasColumnName("Product_Type_ID");
            this.Property(t => t.Manufacturer_ID).HasColumnName("Manufacturer_ID");
            this.Property(t => t.Model_ID).HasColumnName("Model_ID");
            this.Property(t => t.Product_Group_ID).HasColumnName("Product_Group_ID");
            this.Property(t => t.Provider_ID).HasColumnName("Provider_ID");
            this.Property(t => t.Origin).HasColumnName("Origin");
            this.Property(t => t.Barcode).HasColumnName("Barcode");
            this.Property(t => t.Unit_ID).HasColumnName("Unit_ID");
            this.Property(t => t.UnitConvert).HasColumnName("UnitConvert");
            this.Property(t => t.UnitRate).HasColumnName("UnitRate");
            this.Property(t => t.Org_Price).HasColumnName("Org_Price");
            this.Property(t => t.Sale_Price).HasColumnName("Sale_Price");
            this.Property(t => t.Retail_Price).HasColumnName("Retail_Price");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.CurrentCost).HasColumnName("CurrentCost");
            this.Property(t => t.AverageCost).HasColumnName("AverageCost");
            this.Property(t => t.Warranty).HasColumnName("Warranty");
            this.Property(t => t.VAT_ID).HasColumnName("VAT_ID");
            this.Property(t => t.ImportTax_ID).HasColumnName("ImportTax_ID");
            this.Property(t => t.ExportTax_ID).HasColumnName("ExportTax_ID");
            this.Property(t => t.LuxuryTax_ID).HasColumnName("LuxuryTax_ID");
            this.Property(t => t.Customer_ID).HasColumnName("Customer_ID");
            this.Property(t => t.Customer_Name).HasColumnName("Customer_Name");
            this.Property(t => t.CostMethod).HasColumnName("CostMethod");
            this.Property(t => t.MinStock).HasColumnName("MinStock");
            this.Property(t => t.MaxStock).HasColumnName("MaxStock");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Commission).HasColumnName("Commission");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.Expiry).HasColumnName("Expiry");
            this.Property(t => t.LimitOrders).HasColumnName("LimitOrders");
            this.Property(t => t.ExpiryValue).HasColumnName("ExpiryValue");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.Depth).HasColumnName("Depth");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Thickness).HasColumnName("Thickness");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.Currency_ID).HasColumnName("Currency_ID");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            
            this.HasOptional(t => t.UNIT1)
                .WithMany(t => t.PRODUCTs)
                .HasForeignKey(d => d.Unit_ID);

        }
    }
}
