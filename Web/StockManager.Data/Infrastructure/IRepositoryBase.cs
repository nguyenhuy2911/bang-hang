using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //  void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        // T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        ResponseBase<List<T>> GetAll(Page pager, Expression<Func<T, object>> order, bool ascending);
        ResponseBase<T> GetPage(Page pager, Expression<Func<T, bool>> where, Expression<Func<T, object>> order, bool ascending);
    }
}
