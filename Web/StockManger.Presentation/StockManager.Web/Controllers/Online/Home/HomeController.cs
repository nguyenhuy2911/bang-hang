using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Controllers;
using StockManager.Web.Models.Online;
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
        public ActionResult QuickView(int product_Group_Id)
        {
            var model = new QuickViewModel();
            var getProductByGroupRequest = new Get_Products_By_GroupId_Request
            {
                Product_Group_ID = product_Group_Id,
                Page = new Entity.Page(0, int.MaxValue)
            };
            var products = this._IProductService.Get_Products_By_GroupId(getProductByGroupRequest);
            if (products != null && products.Results != null && products.Results.Count > 0)
            {
                model.ListProduct = products.Results;
                var getImgRequest = new Get_Images_By_RelateId_Request
                {
                    Page = new Entity.Page(0, int.MaxValue),
                    RelateId = products.Results[0].Product_Group_ID.ToString()
                };
                var listImg = this._IImagesService.Get_Images_By_RelateId(getImgRequest);
                if (listImg != null && listImg.Results != null && listImg.Results.Count > 0)
                    model.ListImage = listImg.Results;
            }
            return View("~/Views/Online/Home/QuickView.cshtml", model);
        }

        [Route("detail")]
        public ActionResult Detail(int produc_Group_tId)
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