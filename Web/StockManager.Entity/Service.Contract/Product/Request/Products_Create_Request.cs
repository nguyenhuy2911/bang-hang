using System.ComponentModel.DataAnnotations;
namespace StockManager.Entity.Service.Contract
{
    public class Products_Create_Request : RequestBase
    {
        public Products_Create_Request()
        {
           
        }
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 1000000, ErrorMessage = "Giá phải là số")]
        [MaxLength(1000000, ErrorMessage ="Giá phải nhỏ hơn")]
        public decimal? Sale_Price { get; set; }

        [Required(ErrorMessage = "Khối lượng không được để trống")]
        [Range(0, 1000000, ErrorMessage = "Khối lượng phải là số")]        
        public string Size { get; set; }

        [Required(ErrorMessage = "Đơn vị tinh1khong6 được để trống")]
        public string Unit { get; set; }

        [Required]
        public string UserID { get; set; }
    }
}
