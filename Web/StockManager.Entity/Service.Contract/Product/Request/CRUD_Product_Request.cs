using System.ComponentModel.DataAnnotations;
namespace StockManager.Entity.Service.Contract
{
    public class CRUD_Product_Request : RequestBase
    {
        public CRUD_Product_Request()
        {
           
        }
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, 1000000, ErrorMessage = "Giá phải là số")]
        [MaxLength(1000000, ErrorMessage ="Giá phải nhỏ hơn")]
        public decimal? Sale_Price { get; set; }

        [Required(ErrorMessage = "Khối lượng không được để trống")]
        [Range(0, 1000000, ErrorMessage = "Khối lượng phải là số")]        
        public string Size { get; set; }

        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        public string Unit_ID { get; set; }

        [Required(ErrorMessage = "sản phẩm gốc không được bỏ trống")]
        public int Product_Group_ID { get; set; }

        [Required]
        public string UserID { get; set; }
        public string Description { get; set; }


    }
}
