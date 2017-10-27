using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    public class BreadCrumbController : Controller
    {
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View("~/Views/Online/BreadCrumb/Index.cshtml");
        }
    }
}