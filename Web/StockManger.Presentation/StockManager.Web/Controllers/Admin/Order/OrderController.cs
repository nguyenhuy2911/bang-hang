using StockManager.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.Admin.Order
{
    [RoutePrefix("order")]
    public class OrderController : BaseController
    {
        [Route]
        public ActionResult Index()
        {
            var modal = new Order_ViewModel();
            return View("~/Views/Admin/Order/Index.cshtml", modal);
        }
    }
}