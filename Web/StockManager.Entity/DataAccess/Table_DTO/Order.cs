using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManager.Entity.DataAccess
{
    public partial class Order
    {
        public Order()
        {
            this.OrderItem = new List<OrderItem>();
        }
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerTel { get; set; }

        public string ShippingWarId { get; set; }

        public string ShippingStreet { get; set; }

        public string ShippingHomeAddress { get; set; }

        public int OrderStatus { get; set; }

        public int ShippingStatus { get; set; }

        public int PaymentStatus { get; set; }

        public decimal OrderTotal { get; set; }

        public decimal OrderDiscount { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string Note { get; set; }

        public bool? PickUpInStore { get; set; }

        public int? StoreId { get; set; }

        public Guid? OrderGuid { get; set; }

        public string CustomerCurrencyCode { get; set; }

        public decimal? OrderSubtotalExclTax { get; set; }

        public decimal? OrderSubTotalDiscountInclTax { get; set; }

        public decimal? OrderSubTotalDiscountExclTax { get; set; }

        public decimal? OrderShippingInclTax { get; set; }

        public decimal? OrderShippingExclTax { get; set; }

        public decimal? PaymentMethodAdditionalFeeInclTax { get; set; }

        public decimal? PaymentMethodAdditionalFeeExclTax { get; set; }

        public string TaxRates { get; set; }

        public decimal? OrderTax { get; set; }

        public decimal? RefundedAmount { get; set; }

        public bool? RewardPointsWereAdded { get; set; }

        public string CheckoutAttributeDescription { get; set; }

        public string CheckoutAttributesXml { get; set; }

        public int? CustomerLanguageId { get; set; }

        public int? AffiliateId { get; set; }

        public string CustomerIp { get; set; }

        public bool? AllowStoringCreditCardNumber { get; set; }

        public string CardType { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string MaskedCreditCardNumber { get; set; }

        public string CardCvv2 { get; set; }

        public string CardExpirationMonth { get; set; }

        public string CardExpirationYear { get; set; }

        public string AuthorizationTransactionId { get; set; }

        public string AuthorizationTransactionCode { get; set; }

        public string AuthorizationTransactionResult { get; set; }

        public string CaptureTransactionId { get; set; }

        public string CaptureTransactionResult { get; set; }

        public string SubscriptionTransactionId { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public DateTime? PaidDateUtc { get; set; }

        public string ShippingMethod { get; set; }

        public string ShippingRateComputationMethodSystemName { get; set; }

        public string CustomValuesXml { get; set; }
       
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
