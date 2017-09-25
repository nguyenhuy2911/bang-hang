using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Online.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IProductService productService, IImagesService imagesService)
        {
            this._IProductService = productService;
            this._IImagesService = imagesService;
        }

        private readonly IProductService _IProductService;
        private readonly IImagesService _IImagesService;

        [Route]
        public ActionResult Index()
        {
            return View("~/Views/Online/Home/Index.cshtml");
        }

        [Route("home/quick-view")]
        public ActionResult QuickView()
        {
            return View("~/Views/Online/Home/QuickView.cshtml");
        }

        [Route("detail")]
        public ActionResult Detail()
        {
            return View("~/Views/Online/Home/Detail.cshtml");
        }

        [HttpPost]
        [Route("get-newest-items")]
        public string Get_Newest_Items()
        {
            var request = new Get_Product_Groups_Request()
            {
                Page = new Entity.Page(0, 11),
            };
            var response = _IProductService.Get_Product_Groups(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}