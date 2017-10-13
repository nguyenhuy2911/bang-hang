using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.DataAccess
{
   public class ProductType_Attribute_Get_By_ProductType_Id_Parameter
    {
        [SqlParameter(ParameterName = "@ProductType_Id", DbType = DbType.Int64)]
        public int ProductType_Id { get; set; }
    }
}
