using StockManager.Data.Infrastructure;
using StockManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Data.Repository
{
    public interface IImageRepository : IRepositoryBase<Images>
    {
       
    }
    public class ImageRepository : RepositoryBase<Images>, IImageRepository
    {
        public ImageRepository(IDataBaseFactory dataBaseFactory) : base(dataBaseFactory)
        {
        }
    }
}
