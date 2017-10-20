using Common;
using Common.Enum;
using Newtonsoft.Json;
using StockManager.Business;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models;
using StockManager.Web.Models.Admin;
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
        public ProductController(IProductService productService, IUnitService unitService, IImagesService imagesService, IProductAttributeService productAttributeService, IProduct_ProductAttribute_MappingService product_ProductAttribute_MappingService, IProductType_Service productType_Service)
        {
            this._IProductService = productService;
            this._IUnitService = unitService;
            this._IImagesService = imagesService;
            this._IProductAttributeService = productAttributeService;
            this._IProduct_ProductAttribute_MappingService = product_ProductAttribute_MappingService;
            this._IProductType_Service = productType_Service;
        }

        private readonly IProductService _IProductService;

        private readonly IUnitService _IUnitService;

        private readonly IImagesService _IImagesService;

        private readonly IProductAttributeService _IProductAttributeService;

        private readonly IProduct_ProductAttribute_MappingService _IProduct_ProductAttribute_MappingService;

        private readonly IProductType_Service _IProductType_Service;

        /* ========================================================== Get ==================================================================================*/

        private Get_Products_Response GetProducts_Data(GetProducts_Request request)
        {
            var response = _IProductService.GetProducts(request);
            return response;
        }

        private List<SelectListItem> Get_Units_SelectList(string unitId)
        {
            var selectList = new List<SelectListItem>();
            var request = new Get_Unit_Request();
            var datas = _IUnitService.GetUnits(request)?.Results;

            selectList.Add(new SelectListItem() { Text = "Chọn", Value = "" });
            if (datas != null)
            {
                selectList.AddRange(datas.Select(i =>
                                                      new SelectListItem()
                                                      {
                                                          Text = i.Unit_Name,
                                                          Value = i.Unit_ID,
                                                          Selected = i.Unit_ID.Equals(unitId)
                                                      }).ToList());
            }
            return selectList;
        }

        private SelectList Get_Products_Group_SelectList(int? Product_Group_Id)
        {
            var selectList = new SelectList(new List<SelectListItem>());
            var _product_Level1_List = new List<SelectListItem>();
            var request = new Get_Product_Groups_Request()
            {
                Page = new Page(0, int.MaxValue)
            };
            var response = _IProductService.Get_Product_Groups(request);
            _product_Level1_List.Add(new SelectListItem() { Text = "Gốc", Value = "0", Group = new SelectListGroup() { Name = "" } });
            if (response?.Results != null)
            {
                _product_Level1_List.AddRange(response.Results.Select(i =>
                                                               new SelectListItem()
                                                               {
                                                                   Text = string.Format("{0} - {1}", i.ProductGroup_ID, i.ProductGroup_Name),
                                                                   Value = i.ProductGroup_ID.ToString(),
                                                                   Group = new SelectListGroup() { Name = "Chọn" },
                                                                   Selected = i.ProductGroup_ID.Equals(Product_Group_Id)
                                                               }).ToList());
            }
            selectList = new SelectList(_product_Level1_List, "Value", "Text", "Group.Name", 0);
            return selectList;
        }
        private List<SelectListItem> Get_Product_Types_SelectList(int? product_Type_Id)
        {
            var selectList = new List<SelectListItem>();
            var datas = _IProductType_Service.GetAllProductType()?.Results;

            selectList.Add(new SelectListItem() { Text = "Chọn", Value = "" });
            if (datas != null)
            {
                selectList.AddRange(datas.Select(i =>
                                                      new SelectListItem()
                                                      {
                                                          Text = i.Name,
                                                          Value = i.Product_Type_ID.ToString(),
                                                          Selected = i.Product_Type_ID.Equals(product_Type_Id)
                                                      }).ToList());
            }
            return selectList;
        }

        private List<Images_DTO> Get_ListImage_By_Product_GroupId(string product_GroupId)
        {
            var request = new Get_Images_By_RelateId_Request()
            {
                Page = new Page(0, 100),
                RelateId = product_GroupId
            };
            return this._IImagesService.Get_Images_By_RelateId(request)?.Results;
        }

        // ===============================================================================================================================================/

        /* =================================================================== Insert, update, delete ================================================== */

        private string Product_Create(Products_CRUD_ViewModel model)
        {
            if (!ModelState.IsValid)
                return string.Empty;
            var request = new CRUD_Product_Request()
            {
                Product_Name = model.Product_Name,
                Sale_Price = Utility.convertNumber<decimal>(model.Sale_Price),
                Org_Price = Utility.convertNumber<decimal>(model.Org_Price),
                Quantity = Utility.convertNumber<decimal>(model.Quantity),
                Unit_ID = model.Unit_ID,
                Product_Type_ID = model.Product_Type_ID,
                Product_Group_ID = model.Product_Group_ID,
                Description = model.Description

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
                Org_Price = Utility.convertNumber<decimal>(model.Org_Price),
                Quantity = Utility.convertNumber<decimal>(model.Quantity),
                Unit_ID = model.Unit_ID,
                Product_Type_ID = model.Product_Type_ID,
                Product_Group_ID = model.Product_Group_ID,
                Description = model.Description
            };
            var response = _IProductService.UpdateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("UpdateSuccess");

            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        /* ============================================================================================================================================= */

        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var model = new Products_ViewModel();
            return View("~/Views/Admin/Product/Index.cshtml", model);
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
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Product_New_Form()
        {
            var model = Get_Products_CRUD_ViewModel(null);
            return View("~/Views/Admin/Product/Product_Crud_Form.cshtml", model);
        }

        [HttpPost]
        [Route("product-edit-form")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Product_Edit_Form(Product_DTO product)
        {
            var model = Get_Products_CRUD_ViewModel(product);
            return View("~/Views/Admin/PRODUCT/Product_Crud_Form.cshtml", model);
        }

        private Products_CRUD_ViewModel Get_Products_CRUD_ViewModel(Product_DTO _product)
        {
            var model = new Products_CRUD_ViewModel();
            var product = _product;
            if (product != null && _product.Product_ID != 0)
            {
                product = new Product_DTO();
                product = this._IProductService.Get_Product_ById(_product.Product_ID)?.Results;
                var listImages = this.Get_ListImage_By_Product_GroupId(product.Product_ID.ToString());
                model.ListImgJson = JsonConvert.SerializeObject(listImages);
                model.Product_ID = product.Product_ID;
                model.Product_Group_ID = product.Product_Group_ID ?? 0;
                model.Product_Name = product?.Product_Name;
                model.Sale_Price = product?.Sale_Price.ToString();
                model.Org_Price = product?.Org_Price.ToString();
                model.Quantity = product?.Quantity.ToString();
                model.Unit_ID = product?.Unit_ID;
                model.Description = product?.Description;
            }
            model.UnitList = Get_Units_SelectList(product?.Unit_ID);
            model.Product_Group_List = Get_Products_Group_SelectList(product?.Product_Group_ID);
            model.Product_Type_List = new List<SelectListItem>() { new SelectListItem { Value = "", Text = "Chọn" } };
            model.Product_Type_List = Get_Product_Types_SelectList(product?.Product_Type_ID);
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

        [HttpPost]
        [Route("add-product-atribute")]
        public string CreateProductAtribute(CRUD_Product_ProductAttribute_Mapping_Request model)
        {
            try
            {
                var response = this._IProduct_ProductAttribute_MappingService.CreateProduct_ProductAttribute_Mapping(model);
                if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                    response.StatusMessage = Utility.getResourceString("UpdateSuccess");
                string json = JsonConvert.SerializeObject(response);
                return json;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        [HttpPost]
        [Route("get-attributes-by-product-type")]
        public string Get_Attributes_By_ProductType(int? product_Type_Id, int productId)
        {
            var request = new ProductType_Attribute_Get_By_ProductType_Id_Request
            {
                ProductType_Id = product_Type_Id ?? 0
            };
            var response = this._IProductType_Service.Get_ProductType_Attribute_By_ProductType_Id(request);
            var product_Atributes = productId > 0 ? this._IProductAttributeService.Get_ProductAttributes_By_ProductId(productId)?.Results : null;
            if (response != null && response.Results != null && response.Results.Count > 0)
            {
                var _listAtribute_Type = response.Results?.GroupBy(x => new { x.Attrtibute_Type, x.Attrtibute_TypeName })
                                               .Select(o => new Get_ProductAttribute_Types_DTO
                                               {
                                                   Type = o.Key.Attrtibute_Type,
                                                   TypeName = o.Key.Attrtibute_TypeName,
                                                   ProductAttributes = response.Results?.Where(p => p.Attrtibute_Type.Equals(o.Key.Attrtibute_Type))
                                                   .Select(p => new Get_ProductAttributes_DTO
                                                   {
                                                       Id = p.Attribute_Id,
                                                       Name = p.Attrtibute_Name,
                                                       Type = p.Attrtibute_Type,
                                                       TypeName = p.Attrtibute_TypeName,
                                                       Value = p.Attrtibute_Value,
                                                       IsSelected = product_Atributes.Where(x => x.ProductAttributeId == p.Attribute_Id).Count() > 0
                                                   }).ToList()
                                               }).ToList();

                string json = JsonConvert.SerializeObject(_listAtribute_Type);

                return json;
            }
            else
                return string.Empty;
        }

        public ActionResult MERCHANDISE_NEWASESEMBLED_Form()
        {
            return View("PRODUCT_UDC_ASESEMBLED_Form");
        }

    }
}
