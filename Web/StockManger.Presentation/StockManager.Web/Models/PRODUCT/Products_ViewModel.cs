using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.PRODUCT
{
    public class Products_ViewModel : BaseModel
    {
        public Products_ViewModel()
        {
            FunctionName = "Products";
            GridHeader = DataTableGridHelper.GetHeaderJson<ProductList_Col>();
        }
        public string GridHeader { get; set; }

        public ProductList_Col TableColumn { get; set; }

    }
    public class ProductList_Col
    {
        [TableHeader(title ="Id")]
        public string Product_ID { get; set; }

        [TableHeader(title = "Tên sản phẩm")]
        public string Product_Name { get; set; }

        [TableHeader(title = "Giá")]
        public string Sale_Price { set; get; }

        [TableHeader(title = "Khối lượng")]
        public string Quantity { get; set; }

        [TableHeader(title = "Đơn vị tính")]
        public string Unit_ID { get; set; }
    }

}