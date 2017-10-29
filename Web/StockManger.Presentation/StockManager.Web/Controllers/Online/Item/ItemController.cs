using Common;
using Common.Enum;
using StockManager.Business;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Common;
using StockManager.Web.Controllers;
using StockManager.Web.Models.Online;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{

    public class ItemController : BaseController
    {
        public ItemController(IProductService productService, IHomeService homeService, IImagesService imagesService, IProductType_Service productType_Service, IProductAttributeService productAttributeService)
        {
            this._IProductService = productService;
            this._IImagesService = imagesService;
            this._IProductType_Service = productType_Service;
            this._IProductAttributeService = productAttributeService;
            this._IHomeService = homeService;

        }
        private readonly IHomeService _IHomeService;
        private readonly IProductService _IProductService;
        private readonly IImagesService _IImagesService;
        private readonly IProductType_Service _IProductType_Service;
        private readonly IProductAttributeService _IProductAttributeService;

        private List<Product_DTO> Get_Products_ByGroupId(int? Product_Group_ID)
        {
            var request = new Get_Products_By_GroupId_Request
            {
                Product_Group_ID = Product_Group_ID ?? 0,
                Page = new Page(0, int.MaxValue),
                Publish = (int)ACTIVE.ALL
            };
            var data = this._IProductService.Get_Products_By_GroupId(request)?.Results;
            if (data != null)
            {
                foreach (var item in data)
                {
                    var getImgRequest = new Get_Images_By_RelateId_Request
                    {
                        Page = new Entity.Page(0, int.MaxValue),
                        RelateId = item.Product_ID.ToString(),
                        Type = "PRODUCT"
                    };
                    var listImg = this._IImagesService.Get_Images_By_RelateId(getImgRequest)?.Results;
                    item.ListImage = new List<Images_DTO>();
                    item.ListImage = listImg;
                }
            }
            return data;
        }

        public ActionResult Index()
        {
            return View("~/Views/Online/Item/Index.cshtml");
        }

        [Route("detail/{productId}")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Detail(int productId)
        {
            var model = GetDetailViewModel(productId);
            return View("~/Views/Online/Item/Detail.cshtml", model);
        }

        [Route("item/quick-view")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult QuickView(int product_Id)
        {
            var model = GetDetailViewModel(product_Id);
            return View("~/Views/Online/Item/QuickView.cshtml", model);
        }
        private ItemDetailViewModel GetDetailViewModel(int product_Id)
        {
            var model = new ItemDetailViewModel();
            var product = this._IProductService.Get_Product_ById(product_Id)?.Results;
            if (product != null)
            {
                model.Item = product;
                var allSaleItems = Get_Products_ByGroupId(product.Product_Group_ID);
                model.List_Similar_Item = allSaleItems.Where(p => p.Publish == true).ToList();
                model.List_All_Sale_Item = allSaleItems;
            }
            GlobalVariable._listItem = model.List_All_Sale_Item;
            var listViewed = Utility.GetDataFromCookie<List<Product_DTO>>(ConstantKey.Cookie_ViewedItem);
            if (listViewed == null)            
                listViewed = new List<Product_DTO>();
            
            listViewed.Add(product);
            Utility.SetCookie(ConstantKey.Cookie_ViewedItem, listViewed);
            return model;
        }

    }
}