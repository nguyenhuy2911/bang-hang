
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    
namespace StockManager.Entity.Service.Contract
{
    public class Get_Products_By_Id_DTO : Product_DTO
    {
        public Get_Products_By_Id_DTO()
        {
            Product_ProductAttribute_Mapping = new List<Product_ProductAttribute_Mapping_DTO>();
        }
        public  List<Product_ProductAttribute_Mapping_DTO> Product_ProductAttribute_Mapping { get; set; }
    }
}