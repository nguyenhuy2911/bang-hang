﻿using Common.Enum;
using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity;
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
        public HomeController(IProductService productService, IImagesService imagesService, IProductType_Service productType_Service, IProductAttributeService productAttributeService)
        {
            this._IProductService = productService;
            this._IImagesService = imagesService;
            this._IProductType_Service = productType_Service;
            this._IProductAttributeService = productAttributeService;
        }

        private readonly IProductService _IProductService;
        private readonly IImagesService _IImagesService;
        private readonly IProductType_Service _IProductType_Service;
        private readonly IProductAttributeService _IProductAttributeService;

        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            return View("~/Views/Online/Home/Index.cshtml");
        }

        private List<Get_Products_Level2_By_Level1_DTO> Get_Similar_Products(int? product_Level1_Id)
        {
            var request = new Get_Products_Level2_By_Level1_Request
            {
                Product_Level1_Id = product_Level1_Id ?? 0,
                Page = new Page(0, int.MaxValue)
            };
            return this._IProductService.Get_Products_Level2_By_Level1(request)?.Results;
        }

        [Route("home/quick-view")]
        public ActionResult QuickView(int product_Group_Id)
        {
            var model = new QuickViewModel();
            var getProductByGroupRequest = new Get_Products_By_GroupId_Request
            {
                Product_Group_ID = product_Group_Id,
                Publish = (int)ACTIVE.ACTIVE,
                Page = new Entity.Page(0, int.MaxValue)
            };
            var products = this._IProductService.Get_Products_By_GroupId(getProductByGroupRequest);
            if (products != null && products.Results != null && products.Results.Count > 0)
            {
                

                var getImgRequest = new Get_Images_By_RelateId_Request
                {
                    Page = new Entity.Page(0, int.MaxValue),
                    RelateId = products.Results[0].Product_ID.ToString()
                };
                var listImg = this._IImagesService.Get_Images_By_RelateId(getImgRequest)?.Results;

                if (listImg != null && listImg.Count > 0)
                    model.ListImage = listImg;

                

                model.ListProduct = products.Results;
                model.List_Similar_Products = Get_Similar_Products(products.Results[0].Product_Level1);
                foreach (var similar in model.List_Similar_Products)
                {
                    var getattribute_Request = new ProductType_Attribute_Get_By_ProductType_Id_Request
                    {
                        ProductType_Id = similar.Product_Level2
                    };
                    var attributes = this._IProductAttributeService.Get_ProductAttributes_By_ProductId(similar.Product_Level2)?.Results;
                    if (attributes != null && attributes.Count > 0)
                        similar.ProductAttributes = attributes;
                }
            }
            return View("~/Views/Online/Home/QuickView.cshtml", model);
        }

        [Route("detail")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Detail(int produc_Group_tId)
        {
            return View("~/Views/Online/Home/Detail.cshtml");
        }

        [HttpGet]
        [Route("get-newest-items")]
        public string Get_Newest_Items()
        {
            var request = new Get_Products_Level2_Request()
            {
                Page = new Entity.Page(0, 11),
            };
            var response = _IProductService.Get_Products_Level2(request);
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