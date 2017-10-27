using Common.Enum;
using StockManager.Business;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models.Online;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(IProductService productService, IHomeService homeService, IImagesService imagesService, IProductType_Service productType_Service, IProductAttributeService productAttributeService)
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

        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View("~/Views/Online/Home/Index.cshtml");
        }

        [HttpGet]
        [Route("get-newest-items")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Get_Newest_Items()
        {
            var request = new Get_OnlineItem_GetList_Request()
            {
                Page = new Entity.Page(0, 11),
                Publish = (int)ACTIVE.ACTIVE
            };
            var response = _IHomeService.GetItems(request);
            var model = new NewestItemsModel()
            {
                Items = response?.Results
            };
            return View("~/Views/Online/Home/_Home_NewestItems.cshtml", model);
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