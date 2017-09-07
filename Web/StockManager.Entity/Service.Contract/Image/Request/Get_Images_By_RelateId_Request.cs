using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class Get_Images_By_RelateId_Request : RequestBase
    {
        public string RelateId { get; set; }

    }
}
