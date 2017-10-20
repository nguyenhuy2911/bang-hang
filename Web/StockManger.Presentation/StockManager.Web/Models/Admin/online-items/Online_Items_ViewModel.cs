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
        [TableHeader(title = "Id", className = "dt-body-center")]
        public string ProductGroup_ID { get; set; }

        [TableHeader(title = "Hình ảnh", className = "dt-body-left")]
        public string ImagePath { get; set; }

        [TableHeader(title = "Tên sản phẩm", className = "dt-body-left")]
        public string ProductGroup_Name { get; set; }

        [TableHeader(title = "Sửa", className = "dt-body-center")]
        public string Action { get; set; }

    }
    
}