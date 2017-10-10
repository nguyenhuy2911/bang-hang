using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Models
{
    public class SelectList_Group
    {
        public SelectList_Group()
        {
            Items = new List<SelectListItem>();
        }
        public string Name { get; set; }
        public List<SelectListItem> Items { get; set; }
    }
}