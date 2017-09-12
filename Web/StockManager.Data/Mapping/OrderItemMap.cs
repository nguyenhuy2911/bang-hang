using StockManager.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.OrderId)
                .IsRequired();

            this.Property(t => t.ProductId)
                .IsRequired();
            // Table & Column Mappings
            this.ToTable("OrderItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.OriginalProductCost).HasColumnName("OriginalProductCost");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.ItemWeight).HasColumnName("ItemWeight");
            this.Property(t => t.OrderItemGuid).HasColumnName("OrderItemGuid");
            this.Property(t => t.UnitPriceInclTax).HasColumnName("UnitPriceInclTax");
            this.Property(t => t.UnitPriceExclTax).HasColumnName("UnitPriceExclTax");
            this.Property(t => t.PriceExclTax).HasColumnName("PriceExclTax");
            this.Property(t => t.DiscountAmountExclTax).HasColumnName("DiscountAmountExclTax");
            this.Property(t => t.AttributeDescription).HasColumnName("AttributeDescription");
            this.Property(t => t.AttributesXml).HasColumnName("AttributesXml");
            this.Property(t => t.DownloadCount).HasColumnName("DownloadCount");
            this.Property(t => t.IsDownloadActivated).HasColumnName("IsDownloadActivated");
            this.Property(t => t.LicenseDownloadId).HasColumnName("LicenseDownloadId");
            this.Property(t => t.ProroteID).HasColumnName("ProroteID");

            // Relationships
            this.HasOptional(t => t.Order)
                .WithMany(t => t.OrderItem)
                .HasForeignKey(d => d.OrderId);
            this.HasOptional(t => t.PRODUCT)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
