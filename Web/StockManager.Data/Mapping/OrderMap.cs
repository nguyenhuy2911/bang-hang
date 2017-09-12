using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
namespace StockManager.Data.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            this.Property(t => t.CustomerName)
                .HasMaxLength(250);

            this.Property(t => t.CustomerEmail)
               .HasMaxLength(100);

            this.Property(t => t.CustomerTel)
               .HasMaxLength(20);

            this.Property(t => t.ShippingWarId)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.ShippingWarId)
               .HasMaxLength(250);

            this.Property(t => t.ShippingStreet)
               .HasMaxLength(500);

            this.Property(t => t.ShippingHomeAddress)
               .HasMaxLength(500);

            this.Property(t => t.ShippingWarId)
               .HasMaxLength(250);

            this.Property(t => t.ShippingWarId)
               .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Order");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.CustomerEmail).HasColumnName("CustomerEmail");
            this.Property(t => t.CustomerTel).HasColumnName("CustomerTel");
            this.Property(t => t.ShippingWarId).HasColumnName("ShippingWarId");
            this.Property(t => t.ShippingStreet).HasColumnName("ShippingStreet");
            this.Property(t => t.ShippingHomeAddress).HasColumnName("ShippingHomeAddress");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.ShippingStatus).HasColumnName("ShippingStatus");
            this.Property(t => t.PaymentStatus).HasColumnName("PaymentStatus");
            this.Property(t => t.OrderTotal).HasColumnName("OrderTotal");
            this.Property(t => t.OrderDiscount).HasColumnName("OrderDiscount");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.PickUpInStore).HasColumnName("PickUpInStore");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.OrderGuid).HasColumnName("OrderGuid");
            this.Property(t => t.CustomerCurrencyCode).HasColumnName("CustomerCurrencyCode");
            this.Property(t => t.OrderSubtotalExclTax).HasColumnName("OrderSubtotalExclTax");
            this.Property(t => t.OrderSubTotalDiscountInclTax).HasColumnName("OrderSubTotalDiscountInclTax");
            this.Property(t => t.OrderSubTotalDiscountExclTax).HasColumnName("OrderSubTotalDiscountExclTax");
            this.Property(t => t.OrderShippingInclTax).HasColumnName("OrderShippingInclTax");
            this.Property(t => t.OrderShippingExclTax).HasColumnName("OrderShippingExclTax");
            this.Property(t => t.PaymentMethodAdditionalFeeInclTax).HasColumnName("PaymentMethodAdditionalFeeInclTax");
            this.Property(t => t.PaymentMethodAdditionalFeeExclTax).HasColumnName("PaymentMethodAdditionalFeeExclTax");
            this.Property(t => t.TaxRates).HasColumnName("TaxRates");
            this.Property(t => t.OrderTax).HasColumnName("OrderTax");
            this.Property(t => t.RefundedAmount).HasColumnName("RefundedAmount");
            this.Property(t => t.RewardPointsWereAdded).HasColumnName("RewardPointsWereAdded");
            this.Property(t => t.CheckoutAttributeDescription).HasColumnName("CheckoutAttributeDescription");
            this.Property(t => t.CheckoutAttributesXml).HasColumnName("CheckoutAttributesXml");
            this.Property(t => t.CustomerLanguageId).HasColumnName("CustomerLanguageId");
            this.Property(t => t.AffiliateId).HasColumnName("AffiliateId");
            this.Property(t => t.CustomerIp).HasColumnName("CustomerIp");
            this.Property(t => t.AllowStoringCreditCardNumber).HasColumnName("AllowStoringCreditCardNumber");
            this.Property(t => t.CardType).HasColumnName("CardType");
            this.Property(t => t.CardName).HasColumnName("CardName");
            this.Property(t => t.CardNumber).HasColumnName("CardNumber");
            this.Property(t => t.MaskedCreditCardNumber).HasColumnName("MaskedCreditCardNumber");
            this.Property(t => t.CardCvv2).HasColumnName("CardCvv2");
            this.Property(t => t.CardExpirationMonth).HasColumnName("CardExpirationMonth");
            this.Property(t => t.CardExpirationYear).HasColumnName("CardExpirationYear");
            this.Property(t => t.AuthorizationTransactionId).HasColumnName("AuthorizationTransactionId");
            this.Property(t => t.AuthorizationTransactionCode).HasColumnName("AuthorizationTransactionCode");
            this.Property(t => t.AuthorizationTransactionResult).HasColumnName("AuthorizationTransactionResult");
            this.Property(t => t.CaptureTransactionId).HasColumnName("CaptureTransactionId");
            this.Property(t => t.CaptureTransactionResult).HasColumnName("CaptureTransactionResult");
            this.Property(t => t.SubscriptionTransactionId).HasColumnName("SubscriptionTransactionId");
            this.Property(t => t.PurchaseOrderNumber).HasColumnName("PurchaseOrderNumber");
            this.Property(t => t.PaidDateUtc).HasColumnName("PaidDateUtc");
            this.Property(t => t.ShippingMethod).HasColumnName("ShippingMethod");
            this.Property(t => t.ShippingRateComputationMethodSystemName).HasColumnName("ShippingRateComputationMethodSystemName");
            this.Property(t => t.CustomValuesXml).HasColumnName("CustomValuesXml");

            // Relationships
        }
    }
}
