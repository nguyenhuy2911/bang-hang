using Common;
using Newtonsoft.Json;
using StockManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    public class VENDORController : BaseController
    {
        public ActionResult VENDOR_FormList()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new VENDOR_FormList_Model()
            {

            };
            return View("VENDOR_FormList", model);
        }
        //public string Vendor_GridHeader()
        //{
        //    var headers = new List<GridColumn>();
        //    headers.Add(new GridColumn { name = "Index", title = Utility.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Name", title = Utility.getResourceString("Vendor_HeaderName"), width = "40" });
        //    headers.Add(new GridColumn { name = "Address", title = Utility.getResourceString("Vendor_HeaderAddress"), align = JsGridColAlign.center.ToString() });
        //    return JsonConvert.SerializeObject(headers);
        //}
        public ActionResult VENDOR_NEW_Form()
        {
            return View("VENDOR_NEW_UPDATE_Form");
        }
        public ActionResult VENDOR_UPDATE_Form()
        {
            return View("VENDOR_NEW_UPDATE_Form");
        }

    }
}