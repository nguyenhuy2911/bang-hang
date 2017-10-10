using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.Online
{
    public class QuickViewModel
    {
        public List<Get_Products_DTO> ListProduct { get; set; }
        public List<Images_DTO> ListImage { get; set; }
    }
}