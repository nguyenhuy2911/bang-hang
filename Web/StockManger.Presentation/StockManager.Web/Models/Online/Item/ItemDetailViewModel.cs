using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.Online
{
    public class ItemDetailViewModel
    {
        public ItemDetailViewModel()
        {
            ListImage = new List<Images_DTO>();
            List_Similar_Item = new List<Product_DTO>();
            List_All_Sale_Item = new List<Product_DTO>();
            Item = new Product_DTO();
        }
        public List<Product_DTO> List_Similar_Item{ get; set; }
        public List<Product_DTO> List_All_Sale_Item { get; set; }
        public List<Images_DTO> ListImage { get; set; }
        public Product_DTO Item { get; set; }


    }
}