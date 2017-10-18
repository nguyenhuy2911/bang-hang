using System;
using System.Collections.Generic;

namespace StockManager.Entity.Service.Contract
{
    public class Get_Products_Level2_By_Level1_DTO
    {
        public Get_Products_Level2_By_Level1_DTO()
        {
           
        }
        public int Product_Level1 { get; set; }
        public int Product_Level2 { get; set; }
        public string Product_Name { get; set; }
        public decimal Sale_Price { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
        public List<ProductAttribute_DTO> ProductAttributes { get; set; }

    }
}
