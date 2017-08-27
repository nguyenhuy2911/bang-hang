using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.Entity.Infrastructure;

namespace StockManager.Data.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        private StockManagerContext dataContext;

        private IDbSet<T> dbset;
        protected IDataBaseFactory DataBaseFactory { get; set; }
        public RepositoryBase(IDataBaseFactory dataBaseFactory)
        {
            DataBaseFactory = dataBaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected StockManagerContext DataContext
        {
            get
            {
                return dataContext ?? (dataContext = DataBaseFactory.Get());
            }
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(string id)
        {
            var entity = GetById(id);
            dbset.Remove(entity);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual ResponseBase<List<T>> GetAll(Page pager, Expression<Func<T, object>> order, bool ascending)
        {
            var response = new ResponseBase<List<T>>()
            {
                TotalRow = 0
            };
            try
            {
                var query = dbset.SortBy(order, ascending).Skip(pager.Skip).Take(pager.PageSize);
                var result = query.ToList();
                var totalRow = dbset.Count();
                return
                    new ResponseBase<List<T>>()
                    {
                        Results = (List<T>)result,
                        TotalRow = totalRow
                    };
            }
            catch (DbEntityValidationException ex)
            {
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }

        }

        public virtual ResponseBase<List<T>> GetPage(Page pager, Expression<Func<T, bool>> where = null, Expression<Func<T, object>> order = null, bool ascending = false)
        {

            var getDataAsync = this.GetDatas(pager, where, order, ascending);
            var getTotalRowAsync = this.GetTotalCount(where);

            return
                new ResponseBase<List<T>>()
                {
                    Results = getDataAsync,
                    TotalRow = getTotalRowAsync
                };
        }

        private int GetTotalCount(Expression<Func<T, bool>> where = null)
        {
            try
            {

                var query = dbset;
                if (where != null)
                {
                    var total = query.Count(where);
                    return total;
                }
                else
                    return dbset.Count();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        private List<T> GetDatas(Page pager, Expression<Func<T, bool>> where = null, Expression<Func<T, object>> order = null, bool ascending = false)
        {
            try
            {
                var query = dbset.Where(where).SortBy(order, ascending).Skip(pager.Skip).Take(pager.PageSize);

                var result = query.ToList();
                return result;
            }
            catch (Exception ex)
            {

                return new List<T>();
            }
        }

    }
}
