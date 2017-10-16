using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.Admin
{
    public class Online_Items_ViewModel
    {
        public Online_Items_ViewModel()
        {           
            GridHeader = DataTableGridHelper.GetHeaderJson<Items_Grid_Column>();
        }
        public string GridHeader { get; set; }
    }
    public class Items_Grid_Column
    {
        [TableHeader(title = "Id")]
        public string Product_Level2 { get; set; }

        [TableHeader(title = "Hình ảnh")]
        public string ImagePath { get; set; }

        [TableHeader(title = "Tên sản phẩm")]
        public string Product_Name { get; set; }

        [TableHeader(title = "Sửa")]
        public string Action { get; set; }

    }
    
}