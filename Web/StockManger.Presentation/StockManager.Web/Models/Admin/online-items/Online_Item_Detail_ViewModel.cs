using Common;
using System.ComponentModel.DataAnnotations;

namespace StockManager.Web.Models.Admin
{
    public class Online_Item_Detail_ViewModel
    {
        public Online_Item_Detail_ViewModel()
        {
            Item_By_Group_GridHeader = DataTableGridHelper.GetHeaderJson<Items_B_yGroup_Grid_Column>();
        }      
        public int ProductId { get; set; }

        public string Product_Name { get; set; }      
       
        public string Description { get; set; }
        
        public string ListImgJson { get; set; }
        public string Item_By_Group_GridHeader { get; set; }
    }

    public class Items_B_yGroup_Grid_Column
    {
        [TableHeader(title = "Id")]
        public string Product_ID { get; set; }

        [TableHeader(title = "Tên sản phẩm")]
        public string Product_Name { get; set; }

        [TableHeader(title = "Giá")]
        public string Sale_Price { set; get; }

        [TableHeader(title = "Khối lượng")]
        public string Quantity { get; set; }

        [TableHeader(title = "Đơn vị tính")]
        public string Unit_Name { get; set; }

        [TableHeader(title = "Online")]
        public string Publish { get; set; }
    }
}