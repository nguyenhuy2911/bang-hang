
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Entity.Service.Contract
{
    public class Get_Products_By_GroupId_DTO
    {
        public Get_Products_By_GroupId_DTO()
        {

        }
        public int Product_ID { get; set; } = 0;
        public string Product_Name { get; set; } = "";
        public int Product_Type_ID { get; set; } = 0;
        public decimal Sale_Price { set; get; } = 0;
        public decimal Quantity { get; set; } = 0;
        public string Unit_ID { get; set; } = "";
        public string Unit_Name { get; set; } = "";
        public bool Publish { get; set; } = false;
        public int Product_Level1 { get; set; } = 0;
    }
}