using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.Admin
{
    public class DashBoardController : Controller
    {
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View("~/Views/Admin/DASHBOARD/DashBoard.cshtml");
        }
    }
}