using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class Product_Group_DTO
    {
        public Product_Group_DTO()
        {

        }
        public int ProductGroup_ID { get; set; }
        public string ProductGroup_Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
    }
}
