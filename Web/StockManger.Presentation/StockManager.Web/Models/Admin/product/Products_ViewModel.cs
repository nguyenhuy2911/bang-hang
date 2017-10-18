using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Models.Admin
{
    public class Products_ViewModel : BaseModel
    {
        public Products_ViewModel()
        {
            FunctionName = "Products";
            GridHeader = DataTableGridHelper.GetHeaderJson<Product_Grid_Column>();
        }
        public string GridHeader { get; set; }


    }
    public class Product_Grid_Column
    {
        [TableHeader(title = "Id", className = "dt-body-center")]
        public string Product_ID { get; set; }

        [TableHeader(title = "Tên sản phẩm")]
        public string Product_Name { get; set; }

        [TableHeader(title = "Giá", className = "dt-body-right")]
        public string Sale_Price { set; get; }

        [TableHeader(title = "Khối lượng", className = "dt-body-right")]
        public string Quantity { get; set; }

        [TableHeader(title = "Đơn vị tính", className = "dt-body-center")]
        public string Unit_ID { get; set; }

        [TableHeader(title = "Sửa / Xóa", className = "dt-body-center")]
        public string Action { get; set; }
    }

}