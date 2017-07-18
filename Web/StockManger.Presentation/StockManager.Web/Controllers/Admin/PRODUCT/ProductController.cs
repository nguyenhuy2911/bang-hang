using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _IProductService;
        public ProductController(IProductService productService)
        {
            this._IProductService = productService;
        }

        [Route]
        public ActionResult Product_FormList()
        {
            if (!CheckLogin())
            {
                return Login();
            }
            var model = new Products_ViewModel();
            return View("~/Views/Admin/PRODUCT/PRODUCT_FormList.cshtml", model);
        }

        [HttpGet]
        [Route("get-products")]
        public string GetProducts()
        {
            var response = GetProducts_Data();
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        private GetProducts_Response GetProducts_Data()
        {
            var request = new GetProducts_Request();
            var response = _IProductService.GetProducts(request);
            return response;
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("product-create-form")]
        public ActionResult Product_Create_Form()
        {
            return View("~/Views/Admin/PRODUCT/Product_Crud_Form.cshtml");
        }

        [HttpPost]
        [Route("product-create")]
        public string Product_New()
        {
            var response = GetProducts_Data();
            string json = JsonConvert.SerializeObject(response);
            return json;
        }


        public ActionResult MERCHANDISE_NEWASESEMBLED_Form()
        {
            return View("PRODUCT_UDC_ASESEMBLED_Form");
        }

    }
}
