﻿using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace StockManager.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            AdminBundles(bundles);

        }

        private static void AdminBundles(BundleCollection bundles)
        {
            // -------------------------  Bundles Template --------------------------------------- //

            bundles.Add(new StyleBundle("~/Template/Admin/css").Include(
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap/css/bootstrap.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/node-waves/waves.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/animate-css/animate.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/waitme/waitMe.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-select/css/bootstrap-select.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/multi-select/css/multi-select.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/animate-css/animate.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css",
                        "~/Template/Admin/AdminBSBMaterial/plugins/dropzone/dropzone.css",
                        "~/Template/Admin/AdminBSBMaterial/css/style.css",
                        "~/Template/Admin/AdminBSBMaterial/css/themes/all-themes.css",
                        "~/Template/Admin/AdminBSBMaterial/font-awesome/css/font-awesome.min.css",                       
                       // "~/Template/Admin/AdminBSBMaterial/plugins/morrisjs/morris.css",
                        "~/Template/Admin/AdminBSBMaterial/custom.css",
                        "~/Scripts/Lip/jquery-loading/jquery.loading.css"

           ));

            // ----------------------------- Common ----------------------------------------------- //

            bundles.Add(new ScriptBundle("~/Script/Common").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery/jquery.min.js",
                        "~/Scripts/modernizr-2.6.2.js",                        
                        "~/Scripts/Common/Helper.js",
                        "~/Scripts/Common/common-function.js",
                       // "~/Scripts/Common/dataTableExtention.js",
                        "~/Scripts/Function/BaseFunction.js"

            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));

            // --------------------------------  Setup --------------------------------------------- //

            bundles.Add(new ScriptBundle("~/Admin/Setup/js").Include(
                        
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap/js/bootstrap.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-select/js/bootstrap-select.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery-slimscroll/jquery.slimscroll.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/node-waves/waves.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/autosize/autosize.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/momentjs/moment.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/tinymce/tinymce.min.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-notify/bootstrap-notify.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery-datatable/jquery.dataTables.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/dropzone/dropzone.js",
                        "~/Scripts/Lip/jquery-loading/jquery.loading.js",
                        "~/Template/Admin/AdminBSBMaterial/js/admin.js"
                        ));

            // Page 
            // ------------------------- DASHBOARD ----------------------------------------------//
            bundles.Add(new ScriptBundle("~/Script/Function/DashBoard").Include(
                           "~/Template/Admin/AdminBSBMaterial/plugins/chartjs/Chart.bundle.js",
                           "~/Template/Admin/AdminBSBMaterial/js/pages/charts/chartjs.js"
            ));

            // ------------------------- PRODUCT ----------------------------------------------//

          
            bundles.Add(new ScriptBundle("~/Script/Function/Product").Include(
                                         "~/Scripts/Function/Product/Product.js"
            ));

            // ------------------------- Online Item ----------------------------------------------//
            bundles.Add(new ScriptBundle("~/Script/Function/online-items").Include(
                                         "~/Scripts/Function/online-items/online-items.js"
            ));

            // ------------------------- Order ----------------------------------------------//
            bundles.Add(new ScriptBundle("~/Script/Function/orders").Include(
                                         "~/Scripts/Function/orders/orders.js"
            ));
        }

       
              

       

        // ------------------------------------ End ----------------------------------------------//
    }
}
