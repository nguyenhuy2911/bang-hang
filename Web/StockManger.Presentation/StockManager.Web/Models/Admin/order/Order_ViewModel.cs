﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.Admin
{
    public class Order_ViewModel : BaseModel
    {
        public Order_ViewModel()
        {
            GridHeader = DataTableGridHelper.GetHeaderJson<Order_Grid_Column>();
        }
        public string GridHeader { get; set; }


    }
    public class Order_Grid_Column
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

        [TableHeader(title = "Sửa / Xóa")]
        public string Action { get; set; }
    }

}