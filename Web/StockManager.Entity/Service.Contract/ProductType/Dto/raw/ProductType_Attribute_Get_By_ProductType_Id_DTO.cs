using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class ProductType_Attribute_Get_By_ProductType_Id_DTO
    {
        public int Id { get; set; }
        public int ProductType_Id { get; set; }
        public string Product_Type_Name { get; set; }
        public int Attribute_Id { get; set; }
        public string Attrtibute_Name { get; set; }
        public string Attrtibute_Value { get; set; }
        public string Attrtibute_Type { get; set; }
        public string Attrtibute_TypeName { get; set; }
    }
}
