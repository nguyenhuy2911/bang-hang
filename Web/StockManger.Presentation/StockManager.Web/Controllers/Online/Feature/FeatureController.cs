using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models.Online;

namespace StockManager.Web.Controllers
{
    public class FeatureController : Controller
    {
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult RelateItems()
        {
            return View("~/Views/Online/Feature/RelateItems.cshtml");
        }

        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult ViewedItems()
        {
            var ViewedItems = Utility.GetDataFromCookie<List<Product_DTO>>(StockManager.Web.Common.ConstantKey.Cookie_ViewedItem);
            var model = new ViewedItemsModel()
            {
                Items = ViewedItems == null ? new List<Product_DTO>() : ViewedItems
            };
            return View("~/Views/Online/Feature/ViewedItems.cshtml", model);
        }
    }
}