using Common;
using Newtonsoft.Json;
using StockManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.IM_AND_EXPORT.IMPORT
{
    public class IMPORTController : BaseController
    {
        // GET: IMPORT
        public ActionResult IMPORT_FormList()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new IMPORT_FormList_Model()
            {
                //IndayForm_GridHeader = ImPort_IndayForm_GridHeader(),
                //HistoryForm_GridHeader = ImPort_HistoryForm_GridHeader()
            };
            return View("IMPORT_FormList", model);
        }

        //public string ImPort_IndayForm_GridHeader()
        //{
        //    var headers = new List<GridColumn>();
        //    headers.Add(new GridColumn { name = "Index", title = Utility.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "CreateDate", title = Utility.getResourceString("CreateDate"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Status", title = Utility.getResourceString("Status"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Action", title = Utility.getResourceString("Action"), align = JsGridColAlign.center.ToString() });
        //    return JsonConvert.SerializeObject(headers);
        //}

        //public string ImPort_HistoryForm_GridHeader()
        //{
        //    var headers = new List<GridColumn>();
        //    headers.Add(new GridColumn { name = "Index", title = Utility.getResourceString("Index"), width = "20", align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "CreateDate", title = Utility.getResourceString("CreateDate"), align = JsGridColAlign.center.ToString() });
        //    headers.Add(new GridColumn { name = "Status", title = Utility.getResourceString("Status"), align = JsGridColAlign.center.ToString() });
            
        //    return JsonConvert.SerializeObject(headers);
        //}

        public ActionResult IMPORT_NEW_Form()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new IMPORT_New_UpDate_Form_Model()
            {
                //IndayForm_GridHeader = ImPort_IndayForm_GridHeader(),
                //HistoryForm_GridHeader = ImPort_HistoryForm_GridHeader()
            };
            return View("IMPORT_NEW_UPDATE_Form", model);
        }
    }
}