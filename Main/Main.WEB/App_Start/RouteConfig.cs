using System.Web.Mvc;
using System.Web.Routing;

namespace Main.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "admin",
              url: "{controller}/{action}/{type}/{_id}",
              defaults: new { controller = "Admin", action = "Index", _id = UrlParameter.Optional, type = UrlParameter.Optional },
              constraints: new { action = "index|show|edit|create|delete", type = "plds|uavs|gcus|uav|gcu|pld|uavtypes" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                    "CatchAll",
                    "{*url}",
                    new
                    {
                        controller = "Error",
                        action = "NotFound"
                    });
        }
    }
}
