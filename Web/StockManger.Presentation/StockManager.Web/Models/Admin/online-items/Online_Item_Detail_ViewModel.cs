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
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 99999999, ErrorMessage = "Giá phải là số")]
        //  [MaxLength(1000000, ErrorMessage = "Giá phải nhỏ hơn 1,000,000")]
        public string Sale_Price { get; set; }

        [Required(ErrorMessage = "Khối lượng không được để trống")]
        [Range(0, 99999999, ErrorMessage = "Khối lượng phải là số")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string Unit_ID { get; set; }
        [Required(ErrorMessage = "sản phẩm gốc không được bỏ trống")]
        public int ProductGroup_ID { get; set; }

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
        public string Unit_ID { get; set; }

        [TableHeader(title = "")]
        public string Action { get; set; }
    }
}