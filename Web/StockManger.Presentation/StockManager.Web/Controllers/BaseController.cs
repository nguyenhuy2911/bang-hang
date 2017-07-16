using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    public class BaseController: Controller
    {
        protected bool CheckLogin()
        {
            return true;
        }

        protected ActionResult Login()
        {
            return View();
        }
    }
}