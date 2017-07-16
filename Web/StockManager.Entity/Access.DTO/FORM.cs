using System;
using System.Collections.Generic;

namespace StockManager.Entity
{
    public partial class FORM
    {
        public string Form_Id { get; set; }
        public string Form_Caption { get; set; }
        public string ENCaption { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
