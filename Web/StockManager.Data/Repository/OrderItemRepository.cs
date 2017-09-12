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
    public interface IOrderItemRepository : IRepositoryBase<OrderItem>
    {
        
    }
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {      
        public OrderItemRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
          
        }
    }
}




