using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class OnlineItem_GetList_DTO
    {
        public OnlineItem_GetList_DTO()
        {
            Product_Name = string.Empty;
            ProductId = 0;
            Sale_Price = 0;
            ImagePath = string.Empty;
        }
        public int ProductId { get; set; }
        public int ProductGroup_ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Sale_Price { get; set; }
        public string ImagePath { get; set; }
        public bool Publish { get; set; }
    }
}
