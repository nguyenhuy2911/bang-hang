using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockManager.Data.Model.Data
{

    public partial class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal OriginalProductCost { get; set; }

        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public decimal? ItemWeight { get; set; }

        public Guid? OrderItemGuid { get; set; }

        public decimal? UnitPriceInclTax { get; set; }

        public decimal? UnitPriceExclTax { get; set; }

        public decimal? PriceExclTax { get; set; }

        public decimal? DiscountAmountExclTax { get; set; }

        public string AttributeDescription { get; set; }

        public string AttributesXml { get; set; }

        public int? DownloadCount { get; set; }

        public bool? IsDownloadActivated { get; set; }

        public int? LicenseDownloadId { get; set; }

        public int? ProroteID { get; set; }

        public virtual Order Order { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
