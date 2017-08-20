using Common;
using Common.Enum;
using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models;
using StockManager.Web.Models.PRODUCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _IProductService;

        private readonly IUnitService _IUnitService;

        private List<Get_Unit_DTO_Maper> _listUnit { get; set; }

        private void SetListUnit()
        {
            if (_listUnit == null)
            {
                _listUnit = GetUnits_For_CRUD();
            }

        }

        private List<Get_Product_Groups_DTO> _list_Product_Groups => this.Get_Product_Groups_List();


        /************************************ Get **********************************************/

        private Get_Products_Response GetProducts_Data()
        {
            var request = new GetProducts_Request();
            var response = _IProductService.GetProducts(request);
            return response;
        }

        private List<Get_Product_Groups_DTO> Get_Product_Groups_List()
        {
            var request = new Get_Product_Groups_Request()
            {
                Page = new Page(0, 0)
            };
            var response = _IProductService.Get_Product_Groups(request);
            if (response?.Results != null)
                return response.Results;
            else
                return null;
        }

        private List<Get_Unit_DTO_Maper> GetUnits_For_CRUD()
        {

            var request = new Get_Unit_Request();
            return _IUnitService.GetUnits(request)?.Results;
        }

        /***************************************************************************************/

        /************************************ Insert, update, delete ***************************/

        private string Product_Create(Products_CRUD_ViewModel model)
        {
            if (!ModelState.IsValid)
                return string.Empty;
            var request = new CRUD_Product_Request()
            {
                Product_Name = model.Product_Name,
                Sale_Price = Utility.convertNumber<decimal>(model.Sale_Price),
                Size = model.Size,
                Unit_ID = model.Unit_ID,
                Description = model.Description,
                Product_Group_ID = model.ProductGroup_ID
            };
            var response = _IProductService.CreateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("CreateSuccess");

            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        /***************************************************************************************/

        public ProductController(IProductService productService, IUnitService unitService)
        {
            this._IProductService = productService;
            this._IUnitService = unitService;
            this.SetListUnit();
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

        [Route("product-create-form")]
        public ActionResult Product_New_Form()
        {
            var model = new Products_CRUD_ViewModel();
            model.UnitList.Add(new SelectListItem() { Text = "Chọn", Value = "" });
            if (_listUnit != null)
            {
                model.UnitList.AddRange(_listUnit.Select(i =>
                                                           new SelectListItem()
                                                           {
                                                               Text = i.Unit_Name,
                                                               Value = i.Unit_ID
                                                           }).ToList());
            }

            var list_group_product = new List<SelectListItem>();

            list_group_product.Add(new SelectListItem() { Text = "Gốc", Value = "0", Group = new SelectListGroup() { Name = "" } });

            list_group_product.AddRange(_list_Product_Groups.Select(i =>
                                                           new SelectListItem()
                                                           {
                                                               Text = string.Format("{0} - {1}", i.ProductGroup_ID, i.ProductGroup_Name),
                                                               Value = i.ProductGroup_ID.ToString(),
                                                               Group = new SelectListGroup() { Name = "Chọn cha" }
                                                           }).ToList());

            model.Product_Groups_List = new SelectList(list_group_product, "Value", "Text", "Group.Name", 0);

            return View("~/Views/Admin/PRODUCT/Product_Crud_Form.cshtml", model);
        }

        [HttpPost]
        [Route("product-save")]
        public string Product_SaveChange(Products_CRUD_ViewModel model)
        {
            try
            {
                return Product_Create(model);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public ActionResult MERCHANDISE_NEWASESEMBLED_Form()
        {
            return View("PRODUCT_UDC_ASESEMBLED_Form");
        }

    }
}
