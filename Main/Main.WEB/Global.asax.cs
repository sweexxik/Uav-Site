using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Main.BLL.Infrastructure;
using Main.BLL.Models;


namespace Main.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(GcuEditModel), new GcuModelBinder());
            ModelBinders.Binders.Add(typeof(PayloadEditModel), new PayloadModelBinder());
            ModelBinders.Binders.Add(typeof(UavEditModel), new UavModelBinder());
        }
    }
}
