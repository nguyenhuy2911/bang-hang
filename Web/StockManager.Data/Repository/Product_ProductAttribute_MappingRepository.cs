using StockManager.Data.Infrastructure;
using StockManager.Data.StoreProcedure;
using StockManager.Entity;
using StockManager.Entity.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace StockManager.Data.Repository
{
    public interface IProduct_ProductAttribute_MappingRepository : IRepositoryBase<Product_ProductAttribute_Mapping>
    {
    }
    public class Product_ProductAttribute_MappingRepository : RepositoryBase<Product_ProductAttribute_Mapping>, IProduct_ProductAttribute_MappingRepository
    {
        public Product_ProductAttribute_MappingRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {

        }

        
    }
}




