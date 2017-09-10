using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class INVENTORY_DETAILMap : EntityTypeConfiguration<INVENTORY_DETAIL>
    {
        public INVENTORY_DETAILMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RefNo)
                .HasMaxLength(20);

            this.Property(t => t.Stock_ID)
                .HasMaxLength(20);

            this.Property(t => t.Product_Name)
                .HasMaxLength(255);

            this.Property(t => t.Customer_ID)
                .HasMaxLength(20);

            this.Property(t => t.Employee_ID)
                .HasMaxLength(20);

            this.Property(t => t.Batch)
                .HasMaxLength(50);

            this.Property(t => t.Serial)
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Book_ID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("INVENTORY_DETAIL");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RefNo).HasColumnName("RefNo");
            this.Property(t => t.RefDate).HasColumnName("RefDate");
            this.Property(t => t.RefDetailNo).HasColumnName("RefDetailNo");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.RefStatus).HasColumnName("RefStatus");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.Stock_ID).HasColumnName("Stock_ID");
            this.Property(t => t.Product_ID).HasColumnName("Product_ID");
            this.Property(t => t.Product_Name).HasColumnName("Product_Name");
            this.Property(t => t.Customer_ID).HasColumnName("Customer_ID");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.Batch).HasColumnName("Batch");
            this.Property(t => t.Serial).HasColumnName("Serial");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.E_Qty).HasColumnName("E_Qty");
            this.Property(t => t.E_Amt).HasColumnName("E_Amt");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.Property(t => t.Book_ID).HasColumnName("Book_ID");

            // Relationships
            this.HasOptional(t => t.INVENTORY)
                .WithMany(t => t.INVENTORY_DETAIL)
                .HasForeignKey(d => d.StoreID);
            this.HasOptional(t => t.PRODUCT)
                .WithMany(t => t.INVENTORY_DETAIL)
                .HasForeignKey(d => d.Product_ID);
            this.HasOptional(t => t.STOCK)
                .WithMany(t => t.INVENTORY_DETAIL)
                .HasForeignKey(d => d.Stock_ID);

        }
    }
}
