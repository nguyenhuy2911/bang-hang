using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Entity.Service.Contract
{
    public class CRUD_Image_Request : RequestBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string RelateId { get; set; }

    }
}
