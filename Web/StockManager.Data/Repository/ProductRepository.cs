using StockManager.Data.Infrastructure;
using StockManager.Data.StoreProcedure;
using StockManager.Entity;
using StockManager.Data.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Common;

namespace StockManager.Data.Repository
{
    public interface IProductRepository : IRepositoryBase<PRODUCT>
    {
        ResponseBase<List<PRODUCT>> Get_Products(Page page);
        ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups(Product_Group_GetList_Parameter parameterObj);
        ResponseBase<List<Product_GetList_By_GroupId>> Get_Products_By_GroupId(Product_Get_By_Product_Group_ID_Parameter parameterObj);
        ResponseBase<List<OnlineItem_GetList>> Get_OnlineItem_GetList(OnlineItem_GetList_Parameter parameterObj);
        int Update_Product(Product_Update_Parameter parameter);

    }
    public class ProductRepository : RepositoryBase<PRODUCT>, IProductRepository
    {
        private IDbSet<PRODUCT> dbset;
        public ProductRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
            dbset = DataContext.Set<PRODUCT>();
        }

        public ResponseBase<List<PRODUCT>> Get_Products(Page page)
        {
            var query = dbset.Where(p => true)
                            .Include(p => p.UNIT)
                            .Include(p => p.Product_ProductAttribute_Mapping.Select(o => o.ProductAttribute))
                            .SortBy(p => p.Product_ID, false)
                            .Skip(page.Skip)
                            .Take(page.PageSize);
                            
            int rowCount = dbset.Count();
            return new ResponseBase<List<PRODUCT>>()
            {
                Results = query.ToList(),
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<PRODUCT>> Get_Products_By_GroupId(Page page)
        {
            var query = dbset.Where(p => true)
                            .Include(p => p.UNIT)
                            .Include(p => p.Product_ProductAttribute_Mapping.Select(o => o.ProductAttribute))
                            .SortBy(p => p.Product_ID, false)
                            .Skip(page.Skip)
                            .Take(page.PageSize);

            int rowCount = dbset.Count();
            return new ResponseBase<List<PRODUCT>>()
            {
                Results = query.ToList(),
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<PRODUCT_GROUP>> Get_Product_Groups(Product_Group_GetList_Parameter parameterObj)
        {
            int rowCount = 0;
            var data = DataContext.GetListData_By_Stored<PRODUCT_GROUP, Product_Group_GetList_Parameter>(STORENAME.PRODUCT_GROUP_GetList, parameterObj, ref rowCount);
            return new ResponseBase<List<PRODUCT_GROUP>>()
            {
                Results = data,
                TotalRow = rowCount
            };
        }

        public ResponseBase<List<Product_GetList_By_GroupId>> Get_Products_By_GroupId(Product_Get_By_Product_Group_ID_Parameter parameterObj)
        {
            int rowCount = 0;
            var data = DataContext.GetListData_By_Stored<Product_GetList_By_GroupId, Product_Get_By_Product_Group_ID_Parameter>(STORENAME.PRODUCT_GetList_By_GroupId, parameterObj, ref rowCount);
            return new ResponseBase<List<Product_GetList_By_GroupId>>()
            {
                Results = data,
                TotalRow = rowCount
            };
        }
     
        public ResponseBase<List<OnlineItem_GetList>> Get_OnlineItem_GetList(OnlineItem_GetList_Parameter parameterObj)
        {
            int rowCount = 0;
            var datas = DataContext.GetListData_By_Stored<OnlineItem_GetList, OnlineItem_GetList_Parameter>(STORENAME.OnlineItem_GetList, parameterObj, ref rowCount);
            return new ResponseBase<List<OnlineItem_GetList>>()
            {
                Results = datas,
                TotalRow = rowCount
            };
        }
               
        public int Update_Product(Product_Update_Parameter parameter)
        {
            var data = this.Update_ByStore<Product_Update_Parameter>(parameter, STORENAME.PRODUCT_Update);
            return data;
        }


    }
}




