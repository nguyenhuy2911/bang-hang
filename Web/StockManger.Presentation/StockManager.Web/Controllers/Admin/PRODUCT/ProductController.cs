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
        public ProductController(IProductService productService, IUnitService unitService, IImagesService imagesService, IProductAttributeService productAttributeService, IProduct_ProductAttribute_MappingService product_ProductAttribute_MappingService)
        {
            this._IProductService = productService;
            this._IUnitService = unitService;
            this._IImagesService = imagesService;
            this._IProductAttributeService = productAttributeService;
            this._IProduct_ProductAttribute_MappingService = product_ProductAttribute_MappingService;
        }

        private readonly IProductService _IProductService;

        private readonly IUnitService _IUnitService;

        private readonly IImagesService _IImagesService;

        private readonly IProductAttributeService _IProductAttributeService;

        private readonly IProduct_ProductAttribute_MappingService _IProduct_ProductAttribute_MappingService;

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
                Page = new Page(0, int.MaxValue)
            };
            var response = _IProductService.Get_Product_Groups(request);
            if (response?.Results != null)
                return response.Results;
            else
                return null;
        }

        private List<SelectListItem> Units_SelectList()
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
                                                          Value = i.Unit_ID
                                                      }).ToList());
            }
            return selectList;
        }

        private List<Get_ProductAttributes_DTO> Get_List_Attribute()
        {
            var request = new Get_ProductAttributes_Resquest
            {
                Page = new Page()
            };
            var response = this._IProductAttributeService.Get_ProductAttributes(request);
            return response?.Results;
        }

        private SelectList Products_By_Level1_SelectList()
        {
            var selectList = new SelectList(new List<SelectListItem>());
            var _product_Level1_List = new List<SelectListItem>();
            var request = new Product_GetList_By_Level1_Request()
            {
                Page = new Page(0, int.MaxValue)
            };
            var response = _IProductService.GetProducts_By_Level1(request);
            _product_Level1_List.Add(new SelectListItem() { Text = "Gốc", Value = "0", Group = new SelectListGroup() { Name = "" } });
            if (response?.Results != null)
            {
                _product_Level1_List.AddRange(response.Results.Select(i =>
                                                               new SelectListItem()
                                                               {
                                                                   Text = string.Format("{0} - {1}", i.Product_Level1, i.Product_Name),
                                                                   Value = i.Product_Level1.ToString(),
                                                                   Group = new SelectListGroup() { Name = "Chọn" }
                                                               }).ToList());
            }
            selectList = new SelectList(_product_Level1_List, "Value", "Text", "Group.Name", 0);
            return selectList;
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
                Org_Price = Utility.convertNumber<decimal>(model.Org_Price),
                Quantity = Utility.convertNumber<decimal>(model.Quantity),
                Unit_ID = model.Unit_ID,
                Product_Type_ID = model.Product_Type_ID,
                Product_Level1 = model.Product_Level1,
                Product_Level2 = model.Product_Level2

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
                //  Product_Group_ID = model.ProductGroup_ID
            };
            var response = _IProductService.UpdateProduct(request);
            if (response?.StatusCode == (int)RESULT_STATUS_CODE.SUCCESS)
                response.StatusMessage = Utility.getResourceString("UpdateSuccess");

            string json = JsonConvert.SerializeObject(response);
            return json;
        }

        /***************************************************************************************/

        [Route]
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
        public ActionResult Product_New_Form()
        {
            var model = Get_Products_CRUD_ViewModel(0);
            return View("~/Views/Admin/Product/Product_Crud_Form.cshtml", model);
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
            model.UnitList = Units_SelectList();
            model.Product_Level1_List = Products_By_Level1_SelectList();
            model.Product_Level2_List = Get_Products_Level2_SelectList(0);
            model.Product_Type_List = new List<SelectListItem>() { new SelectListItem { Value = "", Text = "Chọn" } };
            var _listAtribute = this.Get_List_Attribute();
            if (_listAtribute != null && _listAtribute.Count > 0)
            {
                var listOfType = _listAtribute?.Select(o => new Get_ProductAttributes_DTO
                {
                    Id = o.Id,
                    Name = o.Name,
                    Type = o.Type,
                    Description = o.Description,
                    Image = o.Image,
                    IsActive = o.IsActive,
                    TypeName = o.TypeName,
                    Value = o.Value,
                });
                var _listAtribute_Group = _listAtribute?.GroupBy(x => new { x.Type, x.TypeName })
                                            .Select(o => new Get_ProductAttribute_Types_DTO
                                            {
                                                Type = o.Key.Type,
                                                TypeName = o.Key.TypeName,
                                                ProductAttributes = listOfType?.Where(p => p.Type.Equals(o.Key.Type)).ToList()
                                            }).ToList();
                model.AtributeType_List = _listAtribute_Group;
            }

            if (!string.IsNullOrEmpty(Id.ToString()) && Id > 0)
            {
                var product = Id != 0 ? _IProductService.Get_Product_ById(Id)?.Results : null;
                string product_UnitId = product?.Unit_ID ?? string.Empty;
                int product_GroupId = product?.Product_Group_ID ?? 0;

                model.Product_ID = Id;
                model.Product_Name = product?.Product_Name;
                model.Sale_Price = product?.Sale_Price.ToString();
                model.Org_Price = product?.Org_Price.ToString();
                model.Quantity = product?.Quantity.ToString();
                model.Unit_ID = product?.Unit_ID;

                model.UnitList.ForEach(p =>
                {
                    if (p.Value.Equals(model.Unit_ID))
                        p.Selected = true;

                });
            }
            return model;
        }

        [HttpPost]
        [Route("get-products-level2-by-product-level1-id-selectlist")]
        public string Get_Products_Level2_By_Level1_Selectlist(int product_Level1_Id)
        {
            List<SelectList_Group> selectList = Get_Products_Level2_SelectList(product_Level1_Id);

            string json = JsonConvert.SerializeObject(selectList);
            return json;
        }

        private List<SelectList_Group> Get_Products_Level2_SelectList(int product_Level1_Id)
        {
            var selectList = new List<SelectList_Group>();
            selectList.Add(new SelectList_Group
            {
                Name = "Gốc",
                Items = new List<SelectListItem>
                {
                        new SelectListItem() { Text = "Gốc", Value = "0" }
                }
            });

            if (product_Level1_Id > 0)
            {
                var _product_Level2_List = new SelectList_Group();
                _product_Level2_List.Name = "Chọn";
                var request = new Product_GetList_Level2_By_Level1_Request
                {
                    Product_Level1_Id = product_Level1_Id,
                    Page = new Page(0, int.MaxValue)
                };
                var response = this._IProductService.GetProducts_Level2_By_Level1(request);
                if (response?.Results != null)
                {

                    _product_Level2_List.Items.AddRange(response.Results.Select(i =>
                                                                   new SelectListItem()
                                                                   {
                                                                       Text = string.Format("{0} - {1}", i.Product_Level1, i.Product_Name),
                                                                       Value = i.Product_Level1.ToString()
                                                                   }).ToList());
                }
                selectList.Add(_product_Level2_List);
            }

            return selectList;
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


        public ActionResult MERCHANDISE_NEWASESEMBLED_Form()
        {
            return View("PRODUCT_UDC_ASESEMBLED_Form");
        }

    }
}
