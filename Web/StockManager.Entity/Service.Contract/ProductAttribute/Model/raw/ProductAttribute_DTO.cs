using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class ProductAttribute_DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }
       
    }
}
