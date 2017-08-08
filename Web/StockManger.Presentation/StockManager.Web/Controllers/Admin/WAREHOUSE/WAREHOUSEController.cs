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
    public class WAREHOUSEController : BaseController
    {
        public ActionResult WAREHOUSE_FormList()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new WAREHOUSE_FormList_Model()
            {
                GridHeader = Vendor_GridHeader()
            };
            return View("WAREHOUSE_FormList", model);
        }
        public string Vendor_GridHeader()
        {
            var headers = new List<GridColumn>();
            headers.Add(new GridColumn { name = "Index", title = Utility.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "Name", title = Utility.getResourceString("Warehouse_Name"), width = "40" });
            headers.Add(new GridColumn { name = "Address", title = Utility.getResourceString("Warehouse_Address"), align = JsGridColAlign.center.ToString() });
            return JsonConvert.SerializeObject(headers);
        }
        public ActionResult WAREHOUSE_NEW_Form()
        {
            return View("WAREHOUSE_NEW_UPDATE_Form");
        }
        public ActionResult WAREHOUSE_UPDATE_Form()
        {
            return View("WAREHOUSE_NEW_UPDATE_Form");
        }
    }
}