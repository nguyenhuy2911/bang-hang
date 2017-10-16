using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.Model.Data
{
    public class Product_GetList_By_GroupId
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Type_ID { get; set; }
        public decimal Sale_Price { set; get; }
        public decimal Quantity { get; set; }
        public string Unit_ID { get; set; }
        public string Unit_Name { get; set; }
        public bool Publish { get; set; }
        public int Product_Level1 { get; set; } 
    }
}
