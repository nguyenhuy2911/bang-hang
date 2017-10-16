using StockManager.Data.Infrastructure;
using StockManager.Data.StoreProcedure;
using StockManager.Entity;
using StockManager.Data.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace StockManager.Data.Repository
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        
    }
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
          
        }
    }
}




