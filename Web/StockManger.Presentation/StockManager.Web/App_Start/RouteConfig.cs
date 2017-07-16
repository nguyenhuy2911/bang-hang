using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StockManager.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /** --------------------------------------- DASHBOARD -------------------------------*/
            routes.MapRoute(
                name: "dash-board",
                url: "dash-board",
                defaults: new { controller = "DashBoard", action = "Index" }
            );

            /** --------------------------------------- Merchandise ---------------------------*/
            routes.MapRoute(
                name: "product-list",
                url: "product-list",
                defaults: new { controller = "Product", action = "Product_FormList" }
            );

            routes.MapRoute(
                            name: "get-products",
                            url: "get-products",
                            defaults: new { controller = "Product", action = "GetProducts" }
            );

            routes.MapRoute(
                            name: "product-create-form",
                            url: "product-create-form",
                            defaults: new { controller = "Product", action = "Product_Create_Form" }
            );


            routes.MapRoute(
                            name: "merchandise-new-assemble",
                            url: "merchandise-new-assemble",
                            defaults: new { controller = "MERCHANDISE", action = "MERCHANDISE_NEWASESEMBLED_Form" }
            );
            /** --------------------------------------- VENDOR -------------------------------*/
            routes.MapRoute(
                name: "vendor-list",
                url: "vendor-list",
                defaults: new { controller = "VENDOR", action = "VENDOR_FormList" }
            );
            routes.MapRoute(
                            name: "vendor-new",
                            url: "vendor-new",
                            defaults: new { controller = "VENDOR", action = "VENDOR_NEW_Form" }
            );

            /** --------------------------------------- WAREHOUSE  -------------------------------*/
            routes.MapRoute(
                name: "warehouse-list",
                url: "warehouse-list",
                defaults: new { controller = "WAREHOUSE", action = "WAREHOUSE_FormList" }
            );
            routes.MapRoute(
                            name: "warehouse-new",
                            url: "warehouse-new",
                            defaults: new { controller = "WAREHOUSE", action = "WAREHOUSE_NEW_Form" }
            );
            /** --------------------------------------- Import  -------------------------------*/
            routes.MapRoute(
                name: "import-list",
                url: "import-list",
                defaults: new { controller = "IMPORT", action = "IMPORT_FormList" }
            );
            routes.MapRoute(
                            name: "import-new-form",
                            url: "import-new-form",
                            defaults: new { controller = "IMPORT", action = "IMPORT_NEW_Form" }
            );

            /** --------------------------------------- Ware house Transfer  -------------------------------*/
            routes.MapRoute(
                name: "warehouse-transfer",
                url: "warehouse-transfer",
                defaults: new { controller = "WAREHOUSETRANSFER", action = "WAREHOUSETRANSFER_Form" }
            );
            routes.MapRoute(
                            name: "warehousetransfer-new-form",
                            url: "warehousetransfer-new-form",
                            defaults: new { controller = "WAREHOUSETRANSFER", action = "WAREHOUSETRANSFER_NEW_Form" }
            );
            /** --------------------------------------- Inventory----  -------------------------------*/
            routes.MapRoute(
                            name: "inventory",
                            url: "inventory",
                            defaults: new { controller = "INVENTORY", action = "INVENTORY_Form" }
            );
            routes.MapRoute(
                            name: "inventory-new-form",
                            url: "inventory-new-form",
                            defaults: new { controller = "INVENTORY", action = "INVENTORY_NEW_Form" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
