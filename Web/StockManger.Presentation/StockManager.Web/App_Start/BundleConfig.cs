using System.Collections;
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

            bundles.Add(new ScriptBundle("~/Template/Admin/js").Include(
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery/jquery.min.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap/js/bootstrap.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/jquery-slimscroll/jquery.slimscroll.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/node-waves/waves.js",
                        "~/Template/Admin/AdminBSBMaterial/plugins/tinymce/tinymce.min.js"
            ));

            bundles.Add(new StyleBundle("~/Template/Admin/css").Include(
                       "~/Template/Admin/AdminBSBMaterial/font-awesome/css/font-awesome.min.css",
                       "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap/css/bootstrap.css",
                       "~/Template/Admin/AdminBSBMaterial/plugins/node-waves/waves.css",
                       "~/Template/Admin/AdminBSBMaterial/plugins/animate-css/animate.css",
                       // "~/Template/Admin/AdminBSBMaterial/plugins/morrisjs/morris.css",
                       "~/Template/Admin/AdminBSBMaterial/css/themes/all-themes.css",
                       "~/Template/Admin/AdminBSBMaterial/css/style.css",
                       "~/Template/Admin/AdminBSBMaterial/custom.css",
                       "~/Scripts/Lip/jquery-loading/jquery.loading.css"

           ));

            // ----------------------------- Common ----------------------------------------------- //

            bundles.Add(new ScriptBundle("~/Script/Common").Include(
                        "~/Scripts/jquery-3.1.1.min.js",                        
                        "~/Scripts/Common/Helper.js",
                         "~/Scripts/Common/initPlugin.js",
                        "~/Scripts/Function/BaseFunction.js"

            ));

            // --------------------------------  Setup --------------------------------------------- //

            bundles.Add(new ScriptBundle("~/Admin/Setup/js").Include(
                        "~/Template/Admin/AdminBSBMaterial/js/admin.js",
                        "~/Scripts/Lip/jquery-loading/jquery.loading.js"
            ));

            // Page 
            // ------------------------- DASHBOARD ----------------------------------------------//
            bundles.Add(new ScriptBundle("~/Script/Function/DashBoard").Include(
                           "~/Template/Admin/AdminBSBMaterial/plugins/chartjs/Chart.bundle.js",
                           "~/Template/Admin/AdminBSBMaterial/js/pages/charts/chartjs.js"
            ));

            // ------------------------- PRODUCT ----------------------------------------------//

            var productStyles = new List<string>();
            productStyles.AddRange(DataTableStyle);
            productStyles.AddRange(SelectStyle);
            bundles.Add(new StyleBundle("~/Styles/Function/Product").Include(
                          productStyles.ToArray()
           ));

            var productScript = new List<string>();
            productScript.AddRange(DataTableScript);
            productScript.AddRange(SelectScript);
         //   productScript.AddRange(CkeditorScript);
            productScript.Add("~/Scripts/Function/PRODUCT/Product.js");
            bundles.Add(new ScriptBundle("~/Script/Function/Product").Include(
                          productScript.ToArray()
            ));
        }

        // ------------------------------------  Plugin Style ----------------------------------------//
        private static string[] DataTableStyle
        {
            get
            {
                return new string[]
                {
                    "~/Template/Admin/AdminBSBMaterial/plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.min.css"
                };
            }
        }      
        private static string[] DataTableScript
        {
            get
            {
                return new string[]
                {
                    "~/Template/Admin/AdminBSBMaterial/plugins/jquery-datatable/jquery.dataTables.js",
                    "~/Template/Admin/AdminBSBMaterial/plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js",
                    "~/Scripts/Common/dataTableExtention.js"
                };
            }
        }

        private static string[] SelectStyle
        {
            get
            {
                return new string[]
                {
                    "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-select/css/bootstrap-select.min.css"
                };
            }
        }
        private static string[] SelectScript
        {
            get
            {
                return new string[]
                {
                    "~/Template/Admin/AdminBSBMaterial/plugins/bootstrap-select/js/bootstrap-select.min.js"
                };
            }
        }

        // ------------------------------------ End ----------------------------------------------//
    }
}
