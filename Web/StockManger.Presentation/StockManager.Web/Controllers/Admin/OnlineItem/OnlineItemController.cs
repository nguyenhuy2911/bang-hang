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
        public ActionResult Index()
        {
            var model = new Online_Items_ViewModel();
            return View("~/Views/Admin/Online-Items/Index.cshtml", model);
        }

        [HttpPost]
        [Route("get-online-items")]
        public string Get_Online_Items(Get_Product_Groups_Request request)
        {
            var response = _IProductService.Get_Product_Groups(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        [HttpPost]
        [Route("get-items-by-group")]
        public string Get_Items_by_group(Get_Products_By_GroupId_Request request)
        {
            var response = _IProductService.Get_Product_ByGroupId(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        [Route("online-item-detail")]
        public ActionResult Item_Detail_Form(int groupId)
        {
            var model = new Online_Item_Detail_ViewModel();

            var product = groupId != 0 ? _IProductService.Get_Product_ById(groupId)?.Results : null;
            string product_UnitId = product?.Unit_ID ?? string.Empty;
            int product_GroupId = product?.Product_Group_ID ?? 0;

            model.Product_ID = groupId;
            model.Product_Name = product?.Product_Name;
            model.ProductGroup_ID = groupId;
            model.Sale_Price = product?.Sale_Price.ToString();
            model.Quantity = product?.Quantity.ToString();
            model.Unit_ID = model?.Unit_ID;
            model.Description = WebUtility.HtmlDecode(product?.Description);
            var listImages = this.Get_ListImage_By_Product_GroupId(groupId.ToString());
            model.ListImgJson = JsonConvert.SerializeObject(listImages);
            return View("~/Views/Admin/Online-Items/Online_Item_Crud_Form.cshtml", model);
        }
    }
}