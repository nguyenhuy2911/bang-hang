using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class STOCK
    {
        public STOCK()
        {
            this.INVENTORY_DETAIL = new List<INVENTORY_DETAIL>();
        }

        public string Stock_ID { get; set; }
        public string Stock_Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Mobi { get; set; }
        public string Manager { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<INVENTORY_DETAIL> INVENTORY_DETAIL { get; set; }
    }
}
