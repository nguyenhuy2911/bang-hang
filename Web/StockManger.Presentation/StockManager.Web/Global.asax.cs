using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StockManager.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run();
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            // int usersOnline = (int)Session["USER_ONLINE"]; //Tên này đặt tùy ý
            // usersOnline += 1;
            // Session["USER_ONLINE"] = usersOnline;
            // sesion cart
            //Session[ConstantKey.SessionCart] = null;
        }
        void Session_End(object sender, EventArgs e)
        {
            // int usersOnline = (int)Session["USER_ONLINE"];
            // usersOnline -= 1;
            // Session["USER_ONLINE"] = usersOnline;
            // remove session cart
           // Session.Remove(ConstantKey.SessionCart);
        }
    }
}
