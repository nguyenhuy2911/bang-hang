using System;
using System.Collections.Generic;

namespace StockManager.Entity.DataAccess
{
    public partial class SYS_COMPANY
    {
        public string Company_Id { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Tax { get; set; }
        public string Licence { get; set; }
        public byte[] Photo { get; set; }
    }
}
