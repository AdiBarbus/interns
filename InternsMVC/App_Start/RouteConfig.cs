using System.Web.Mvc;
using System.Web.Routing;

namespace InternsMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(null, "Page{page}", new { Controller = "Domain", action = "GetAllDomains" });
            //routes.MapRoute(null, "Page{page}", new { Controller = "Advertise", action = "GetAllAdvertises" });

            routes.MapRoute(
                "Mazga",
                "{controller}/{action}/Page{page}"
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
