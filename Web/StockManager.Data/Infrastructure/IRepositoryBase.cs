using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Update(T entity, object entityId);      
        void Delete(T entity);
        void Delete(object id);
        ResponseBase<T> GetById(long id);
        ResponseBase<T> GetById(string id);
        ResponseBase<List<T>> GetAll();
        ResponseBase<List<T>>  GetPage(Page pager, Expression<Func<T, bool>> where = null, Expression<Func<T, object>> order = null, bool ascending = false);
    }
}
