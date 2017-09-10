using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class BOOK
    {
        public System.Guid ID { get; set; }
        public string BookName { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Closed { get; set; }
        public Nullable<bool> IsPublic { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string OwnerID { get; set; }
        public string Description { get; set; }
        public Nullable<long> Sorted { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
