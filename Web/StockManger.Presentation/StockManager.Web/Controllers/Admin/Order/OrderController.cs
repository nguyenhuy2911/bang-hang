using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.Admin.Order
{
    [RoutePrefix("orders")]
    public class OrderController : BaseController
    {
        public OrderController(IOrderService orderService)
        {
            this._IProductService = orderService;
        }
        private readonly IOrderService _IProductService;
        private Get_Orders_Response Get_Orders_Data(Get_Orders_Request request)
        {
            var response = _IProductService.GetOrders(request);
            return response;
        }
        [Route]
        public ActionResult Index()
        {
            var modal = new Orders_ViewModel();
            return View("~/Views/Admin/Order/Index.cshtml", modal);
        }

        [HttpPost]
        [Route("get-orders")]
        public string Get_Orders(Get_Orders_Request request)
        {
            var response = this.Get_Orders_Data(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }
    }
}