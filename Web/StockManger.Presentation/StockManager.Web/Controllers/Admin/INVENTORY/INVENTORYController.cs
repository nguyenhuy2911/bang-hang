using Common;
using Newtonsoft.Json;
using StockManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.INVENTORY
{
    public class INVENTORYController : BaseController
    {
        // GET: INVENTORY
        public ActionResult INVENTORY_Form()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new INVENTORY_Form_Model()
            {
                IndayForm_GridHeader = IndayForm_GridHeader(),
                HistoryForm_GridHeader = HistoryForm_GridHeader()
            };
            return View("INVENTORY_Form", model);
        }
        private string IndayForm_GridHeader()
        {
            var headers = new List<GridColumn>();
            headers.Add(new GridColumn { name = "Index", title = Utilies.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "FromWareHouse", title = Utilies.getResourceString("FromWareHouse"), width = "40" });
            headers.Add(new GridColumn { name = "ToWareHouse", title = Utilies.getResourceString("ToWareHouse"), align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "CreateDate", title = Utilies.getResourceString("CreateDate"), align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "Status", title = Utilies.getResourceString("Status"), align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "Action", title = Utilies.getResourceString("Action"), align = JsGridColAlign.center.ToString() });
            return JsonConvert.SerializeObject(headers);
        }

        private string HistoryForm_GridHeader()
        {
            var headers = new List<GridColumn>();
            headers.Add(new GridColumn { name = "Index", title = Utilies.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "FromWareHouse", title = Utilies.getResourceString("FromWareHouse"), width = "40" });
            headers.Add(new GridColumn { name = "ToWareHouse", title = Utilies.getResourceString("ToWareHouse"), align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "CreateDate", title = Utilies.getResourceString("CreateDate"), align = JsGridColAlign.center.ToString() });
            headers.Add(new GridColumn { name = "Status", title = Utilies.getResourceString("Status"), align = JsGridColAlign.center.ToString() });
            return JsonConvert.SerializeObject(headers);
        }

        public ActionResult INVENTORY_NEW_Form()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new INVENTORY_New_UpDate_Form_Model();
            return View("INVENTORY_NEW_AND_UPDATE_Form", model);
        }

    }
}