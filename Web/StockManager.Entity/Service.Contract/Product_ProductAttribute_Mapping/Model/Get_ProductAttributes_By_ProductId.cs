using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class Get_ProductAttributes_By_ProductId : Product_ProductAttribute_Mapping_DTO
    {
        public ProductAttribute_DTO ProductAttribute { get; set; }
    }
}
