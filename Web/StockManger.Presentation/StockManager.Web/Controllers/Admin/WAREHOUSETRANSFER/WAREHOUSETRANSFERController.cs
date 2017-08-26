using Common;
using Newtonsoft.Json;
using StockManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.WAREHOUSETRANSFER
{
    public class WAREHOUSETRANSFERController : BaseController
    {
        // GET: WAREHOUSETRANSFER
        public ActionResult WAREHOUSETRANSFER_Form()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new WAREHOUSETRANSFER_Form_Model()
            {
                //IndayForm_GridHeader = IndayForm_GridHeader(),
                //HistoryForm_GridHeader = HistoryForm_GridHeader()
            };
            return View("WAREHOUSETRANSFER_Form", model);
        }

        //private string IndayForm_GridHeader()
        //{
        //    var headers = new List<GridColumn>();
        //    headers.Add(new GridColumn { name = "Index", title = Utility.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "FromWareHouse", title = Utility.getResourceString("FromWareHouse"), width = "40" });
        //    headers.Add(new GridColumn { name = "ToWareHouse", title = Utility.getResourceString("ToWareHouse"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "CreateDate", title = Utility.getResourceString("CreateDate"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Status", title = Utility.getResourceString("Status"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Action", title = Utility.getResourceString("Action"), align = JsGridColAlign.center.ToString() });
        //    return JsonConvert.SerializeObject(headers);
        //}

        //private string HistoryForm_GridHeader()
        //{
        //    var headers = new List<GridColumn>();
        //    headers.Add(new GridColumn { name = "Index", title = Utility.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "FromWareHouse", title = Utility.getResourceString("FromWareHouse"), width = "40" });
        //    headers.Add(new GridColumn { name = "ToWareHouse", title = Utility.getResourceString("ToWareHouse"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "CreateDate", title = Utility.getResourceString("CreateDate"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Status", title = Utility.getResourceString("Status"), align = JsGridColAlign.center.ToString() });
        //    return JsonConvert.SerializeObject(headers);
        //}

        public ActionResult WAREHOUSETRANSFER_NEW_Form()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new WAREHOUSETRANSFER_New_UpDate_Form_Model();
            return View("WAREHOUSETRANSFER_NEW_AND_UPDATE_Form", model);
        }
    }
}