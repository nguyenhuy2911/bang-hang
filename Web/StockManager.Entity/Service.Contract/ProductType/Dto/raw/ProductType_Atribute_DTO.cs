using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class ProductType_Atribute_DTO
    {
        public int Id { get; set; }
        public int ProductType_Id { get; set; }
        public int Attribute_Id { get; set; }        
    }
}
