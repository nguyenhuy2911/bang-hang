using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class REPORT
    {
        public string Report_ID { get; set; }
        public string Report_Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string DataSet { get; set; }
        public string Class { get; set; }
        public string Parent_ID { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<bool> Avtive { get; set; }
    }
}
