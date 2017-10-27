using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View("~/Views/Online/Feature/ViewedItems.cshtml");
        }
    }
}