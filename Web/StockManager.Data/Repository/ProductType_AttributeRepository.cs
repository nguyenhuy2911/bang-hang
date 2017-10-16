using StockManager.Data.Infrastructure;
using StockManager.Data.StoreProcedure;
using StockManager.Entity;
using StockManager.Data.Model.Data;
using System.Collections.Generic;

namespace StockManager.Data.Repository
{
    public interface IProductType_AttributeRepository : IRepositoryBase<ProductType_Attribute>
    {
        ResponseBase<List<ProductType_Attribute_Get_By_ProductType_Id>> ProductType_Attribute_Get_By_ProductType_Id(ProductType_Attribute_Get_By_ProductType_Id_Parameter parameterObj);
    }
    public class ProductType_AttributeRepository : RepositoryBase<ProductType_Attribute>, IProductType_AttributeRepository
    {
        public ProductType_AttributeRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
        }
        public ResponseBase<List<ProductType_Attribute_Get_By_ProductType_Id>> ProductType_Attribute_Get_By_ProductType_Id(ProductType_Attribute_Get_By_ProductType_Id_Parameter parameterObj)
        {
            int rowCount = 0;
            var datas = DataContext.GetListData_By_Stored<ProductType_Attribute_Get_By_ProductType_Id, ProductType_Attribute_Get_By_ProductType_Id_Parameter>(STORENAME.ProductType_Attribute_Get_By_ProductType_Id, parameterObj, ref rowCount);
            return new ResponseBase<List<ProductType_Attribute_Get_By_ProductType_Id>>()
            {
                Results = datas,
                TotalRow = rowCount
            };
        }

    }
}
