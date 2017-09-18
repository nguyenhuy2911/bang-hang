using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class CRUD_Product_ProductAttribute_Mapping_Request: RequestBase
    {
        public CRUD_Product_ProductAttribute_Mapping_Request()
        {
            Page = new Page();
        }
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ProductAttributeId { get; set; }
        public string Type { get; set; }
        public Page Page { get; set; }
    }
}
