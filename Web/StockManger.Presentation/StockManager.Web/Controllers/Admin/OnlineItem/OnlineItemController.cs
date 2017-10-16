using StockManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManager.Web.Models.Admin;
using StockManager.Entity.Service.Contract;
using StockManager.Entity;
using Newtonsoft.Json;
using System.Net;
using Common.Enum;
using Common;

namespace StockManager.Web.Controllers.Admin.OnlineItem
{
    [RoutePrefix("online-items")]
    public class OnlineItemController : BaseController
    {
        public OnlineItemController(IProductService productService, IImagesService imagesService)
        {
            this._IProductService = productService;
            this._IImagesService = imagesService;
        }

        private readonly IProductService _IProductService;
        private readonly IImagesService _IImagesService;

        private List<Images_DTO> Get_ListImage_By_Product_GroupId(string product_GroupId)
        {
            var request = new Get_Images_By_RelateId_Request()
            {
                Page = new Page(0, 100),
                RelateId = product_GroupId
            };
            return this._IImagesService.Get_Images_By_RelateId(request)?.Results;
        }

        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var model = new Online_Items_ViewModel();
            return View("~/Views/Admin/Online-Items/Index.cshtml", model);
        }

        [HttpPost]
        [Route("get-online-items")]
        public string Get_Online_Items(Get_Products_Level2_Request request)
        {
            var response = _IProductService.Get_Products_Level2(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        [HttpPost]
        [Route("get-products-by-item")]
        public string Get_Products_By_Item(Get_Products_By_GroupId_Request model)
         {
            var request = new Get_Products_By_GroupId_Request
            {
                Page = model.Page,
                Product_Group_ID = model.Product_Group_ID,
                Publish = (int)ACTIVE.ALL
            };
            var response = _IProductService.Get_Products_By_GroupId(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        [Route("online-item-detail")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Item_Detail_Form(int productId)
        {
            var model = new Online_Item_Detail_ViewModel();

            var product = productId != 0 ? _IProductService.Get_Product_ById(productId)?.Results : null;
            string product_UnitId = product?.Unit_ID ?? string.Empty;
            int product_GroupId = product?.Product_Group_ID ?? 0;

            model.ProductId = productId;
            model.Product_Name = product?.Product_Name;
            model.Description = WebUtility.HtmlDecode(product?.Description);
            var listImages = this.Get_ListImage_By_Product_GroupId(productId.ToString());
            model.ListImgJson = JsonConvert.SerializeObject(listImages);
            return View("~/Views/Admin/Online-Items/Online_Item_Crud_Form.cshtml", model);
        }

        [HttpPost]
        [Route("online-item-update")]
        public string Item_Update(Online_Item_Detail_ViewModel model)
        {
            var request = new CRUD_Product_Request()
            {
                Product_ID = model.ProductId,
                Description = WebUtility.HtmlEncode(model.Description),
            };
            var response = _IProductService.UpdateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("UpdateSuccess");
            string json = JsonConvert.SerializeObject(response);
            return json;

        }

        [HttpPost]
        [Route("online-item-update-publishstatus")]
        public string Item_Update_PublishStatus(int productId, int publishStatus)
        {
            var request = new CRUD_Product_Request()
            {
                Product_ID = productId,
                Publish = publishStatus,
            };
            var response = _IProductService.UpdateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("UpdateSuccess");
            string json = JsonConvert.SerializeObject(response);
            return json;

        }
    }
}