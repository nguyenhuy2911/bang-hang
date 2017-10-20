using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.Web.Models.Online
{
    public class NewestItemsModel
    {
       public List<OnlineItem_GetList_DTO> Items { get;set; }
    }
}