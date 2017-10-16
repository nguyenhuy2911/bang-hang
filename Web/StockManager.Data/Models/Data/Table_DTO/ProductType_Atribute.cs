using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.Model.Data
{
    public class ProductType_Attribute
    {
        public int Id { get; set; }
        public int ProductType_Id { get; set; }
        public int Attribute_Id { get; set; }
        public virtual Product_Type Product_Type { get; set; }
        public virtual ProductAttribute Attribute { get; set; }
    }
}
