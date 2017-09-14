using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class PRODUCT
    {
        public PRODUCT()
        {
            this.ADJUSTMENT_DETAIL = new List<ADJUSTMENT_DETAIL>();
            this.INVENTORY_DETAIL = new List<INVENTORY_DETAIL>();
            this.STOCK_INWARD_DETAIL = new List<STOCK_INWARD_DETAIL>();
            this.STOCK_OUTWARD_DETAIL = new List<STOCK_OUTWARD_DETAIL>();
            this.STOCK_TRANSFER_DETAIL = new List<STOCK_TRANSFER_DETAIL>();
            this.OrderItems = new List<OrderItem>();
        }

        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_NameEN { get; set; }
        public Nullable<int> Product_Type_ID { get; set; }
        public Nullable<int> Manufacturer_ID { get; set; }
        public string Model_ID { get; set; }
        public Nullable<int> Product_Group_ID { get; set; }
        public string Provider_ID { get; set; }
        public string Origin { get; set; }
        public string Barcode { get; set; }
        public string Unit_ID { get; set; }
        public string UnitConvert { get; set; }
        public Nullable<decimal> UnitRate { get; set; }
        public Nullable<decimal> Org_Price { get; set; }
        public Nullable<decimal> Sale_Price { get; set; }
        public Nullable<decimal> Retail_Price { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> CurrentCost { get; set; }
        public Nullable<decimal> AverageCost { get; set; }
        public Nullable<int> Warranty { get; set; }
        public Nullable<decimal> VAT_ID { get; set; }
        public Nullable<decimal> ImportTax_ID { get; set; }
        public Nullable<decimal> ExportTax_ID { get; set; }
        public Nullable<decimal> LuxuryTax_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<short> CostMethod { get; set; }
        public Nullable<decimal> MinStock { get; set; }
        public Nullable<decimal> MaxStock { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Commission { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public Nullable<bool> Expiry { get; set; }
        public Nullable<decimal> LimitOrders { get; set; }
        public Nullable<decimal> ExpiryValue { get; set; }
        public Nullable<bool> Batch { get; set; }
        public Nullable<decimal> Depth { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Thickness { get; set; }
        public string Size { get; set; }
        public byte[] Photo { get; set; }
        public string Currency_ID { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string Stock_ID { get; set; }
        public string UserID { get; set; }
        public Nullable<bool> Serial { get; set; }
        public bool Active { get; set; }
        public Nullable<bool> Publish { get; set; }
        public virtual ICollection<ADJUSTMENT_DETAIL> ADJUSTMENT_DETAIL { get; set; }
        public virtual ICollection<INVENTORY_DETAIL> INVENTORY_DETAIL { get; set; }

        public virtual UNIT UNIT1 { get; set; }
        public virtual ICollection<STOCK_INWARD_DETAIL> STOCK_INWARD_DETAIL { get; set; }
        public virtual ICollection<STOCK_OUTWARD_DETAIL> STOCK_OUTWARD_DETAIL { get; set; }
        public virtual ICollection<STOCK_TRANSFER_DETAIL> STOCK_TRANSFER_DETAIL { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Product_ProductAttribute_Mapping> Product_ProductAttribute_Mapping { get; set; }
    }
}
