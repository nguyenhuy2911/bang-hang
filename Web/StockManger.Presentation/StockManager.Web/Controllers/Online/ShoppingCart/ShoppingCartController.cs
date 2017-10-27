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

        public ActionResult HeaderMiniCartItem()
        {
            return View("~/Views/Online/ShoppingCart/HeaderMiniCartItem.cshtml");
        }

        [HttpPost]
        [Route("shoppingcart/add-to-cart")]
        public void AddToCard(int productId)
        {
            var detailProduct = ConstantKey.ListItem;
            var addedProduct = detailProduct.Find(p => p.Product_ID == productId);
            var shoppingCartItem = new ShoppingCartItem()
            {
                ProductID = addedProduct.Product_ID,
                ProductName = addedProduct.Product_Name,
                Price = addedProduct.Sale_Price ?? 0,
                Quantity = 1
           
            };
            var shoppingCartModel = new ShoppingCartModel();
            shoppingCartModel.AddToCart(shoppingCartItem);
        }
    }
}