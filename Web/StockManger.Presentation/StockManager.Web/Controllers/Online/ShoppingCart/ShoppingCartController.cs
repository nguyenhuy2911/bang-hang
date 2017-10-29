using Common.Enum;
using Newtonsoft.Json;
using StockManager.Entity;
using StockManager.Web.Common;
using StockManager.Web.Models.Online;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers.Online
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult HeaderMiniCartItem()
        {
            var model = new ShoppingCartModel();
            return View("~/Views/Online/ShoppingCart/HeaderMiniCartItem.cshtml", model);
        }

        [HttpPost]
        [Route("shoppingcart/add-to-cart")]
        public string AddToCart(int productId, int quantity)
        {
            var detailProduct = GlobalVariable._listItem;
            var addedProduct = detailProduct.Find(p => p.Product_ID == productId);
            var shoppingCartItem = new ShoppingCartItem()
            {
                ProductID = addedProduct.Product_ID,
                ProductName = addedProduct.Product_Name,
                Price = addedProduct.Sale_Price ?? 0,
                ProductImage = addedProduct.ListImage.FirstOrDefault().Path,
                Quantity = quantity,
            };
            var shoppingCartModel = new ShoppingCartModel();
            shoppingCartModel.Cart.AddToCart(shoppingCartItem);
            var data = new ResponseBase<int>()
            {
                StatusCode = (int)RESULT_STATUS_CODE.SUCCESS
            };
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        [HttpPost]
        [Route("shoppingcart/delete-cart-item")]
        public string DeleteCart(int productId)
        {
            var shoppingCartModel = new ShoppingCartModel();
            shoppingCartModel.Cart.RemoveFromCart(productId);
            var data = new ResponseBase<int>()
            {
                StatusCode = (int)RESULT_STATUS_CODE.SUCCESS
            };
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        [HttpPost]
        [Route("shoppingcart/update-cart-item")]
        public string UpdateCart(int productId, int quantity)
        {
            var shoppingCartModel = new ShoppingCartModel();
            shoppingCartModel.Cart.UpdateQuantity(productId, quantity);
            var data = new ResponseBase<int>()
            {
                StatusCode = (int)RESULT_STATUS_CODE.SUCCESS
            };
            string json = JsonConvert.SerializeObject(data);
            return json;
        }
    }
}