using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            TotalRow = 0;
        }
        public T Results { get; set; }

        public int TotalRow { get; set; }
    }
}
