using Common;
using Common.Enum;
using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models.PRODUCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : BaseController
    {
        public ProductController(IProductService productService, IUnitService unitService, IImagesService imagesService)
        {
            this._IProductService = productService;
            this._IUnitService = unitService;
            this._IImagesService = imagesService;
        }

        private readonly IProductService _IProductService;

        private readonly IUnitService _IUnitService;

        private readonly IImagesService _IImagesService;

        /************************************ Get **********************************************/

        private Get_Products_Response GetProducts_Data(GetProducts_Request request)
        {
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

        private List<Images_DTO> Get_ListImage_By_Product_GroupId(string product_GroupId)
        {
            var request = new Get_Images_By_RelateId_Request()
            {
                RelateId = product_GroupId
            };
            return this._IImagesService.Get_Images_By_RelateId(request)?.Results;
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
                Quantity = Utility.convertNumber<decimal>(model.Quantity),
                Unit_ID = model.Unit_ID,
                Description = WebUtility.HtmlEncode(model.Description),
                Product_Group_ID = model.ProductGroup_ID
            };
            var response = _IProductService.CreateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("CreateSuccess");

            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        private string Product_Update(Products_CRUD_ViewModel model)
        {
            if (!ModelState.IsValid)
                return string.Empty;
            var request = new CRUD_Product_Request()
            {
                Product_ID = model.Product_ID,
                Product_Name = model.Product_Name,
                Sale_Price = Utility.convertNumber<decimal>(model.Sale_Price),
                Quantity = Utility.convertNumber<decimal>(model.Quantity),
                Unit_ID = model.Unit_ID,
                Description = WebUtility.HtmlEncode(model.Description),
                Product_Group_ID = model.ProductGroup_ID
            };
            var response = _IProductService.UpdateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("UpdateSuccess");

            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        /***************************************************************************************/



        [Route]
        public ActionResult Product_FormList()
        {

            var model = new Products_ViewModel();
            return View("~/Views/Admin/PRODUCT/PRODUCT_FormList.cshtml", model);
        }

        [HttpPost]
        [Route("get-products")]
        public string GetProducts(GetProducts_Request request)
        {
            var response = GetProducts_Data(request);
            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        [Route("product-create-form")]
        public ActionResult Product_New_Form()
        {
            var model = Get_Products_CRUD_ViewModel(0);
            return View("~/Views/Admin/PRODUCT/Product_Crud_Form.cshtml", model);
        }

        [Route("product-edit-form")]
        public ActionResult Product_Edit_Form(int Id)
        {
            var model = Get_Products_CRUD_ViewModel(Id);
            return View("~/Views/Admin/PRODUCT/Product_Crud_Form.cshtml", model);
        }

        private Products_CRUD_ViewModel Get_Products_CRUD_ViewModel(int Id)
        {
            var model = new Products_CRUD_ViewModel();

            var product = Id != 0 ? _IProductService.Get_Product_ById(Id)?.Results : null;
            string product_UnitId = product?.Unit_ID ?? string.Empty;
            int product_GroupId = product?.Product_Group_ID ?? 0;

            model.Product_ID = Id;
            model.Product_Name = product?.Product_Name;
            model.ProductGroup_ID = product?.Product_Group_ID ?? 0;
            model.Sale_Price = product?.Sale_Price.ToString();
            model.Quantity = product?.Quantity.ToString();
            model.Unit_ID = model?.Unit_ID;
            model.Description = WebUtility.HtmlDecode(product?.Description);

            model.UnitList.Add(new SelectListItem() { Text = "Chọn", Value = "" });
            model.UnitList.AddRange(this.GetUnits_For_CRUD()?.Select(i =>
                                                       new SelectListItem()
                                                       {
                                                           Text = i.Unit_Name,
                                                           Value = i.Unit_ID,
                                                           Selected = product_UnitId.Equals(i.Unit_ID) ? true : false
                                                       }).ToList());


            var list_group_product = new List<SelectListItem>();

            list_group_product.Add(new SelectListItem() { Text = "Gốc", Value = "0", Group = new SelectListGroup() { Name = "" } });

            list_group_product.AddRange(this.Get_Product_Groups_List()?.Select(i =>
                                                           new SelectListItem()
                                                           {
                                                               Text = string.Format("{0} - {1}", i.ProductGroup_ID, i.ProductGroup_Name),
                                                               Value = i.ProductGroup_ID.ToString(),
                                                               Selected = product_GroupId.Equals(i.ProductGroup_ID) ? true : false,
                                                               Group = new SelectListGroup() { Name = "Chọn cha" }
                                                           }).ToList());

            model.Product_Groups_List = new SelectList(list_group_product, "Value", "Text", "Group.Name", 0);
            var listImages = this.Get_ListImage_By_Product_GroupId(product_GroupId.ToString());
            model.ListImgJson = JsonConvert.SerializeObject(listImages);

            return model;
        }

        [HttpPost]
        [Route("product-save")]
        public string Product_SaveChange(Products_CRUD_ViewModel model)
        {
            try
            {
                if (model.Product_ID.Equals(0))
                    return Product_Create(model);
                else
                    return Product_Update(model);
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
