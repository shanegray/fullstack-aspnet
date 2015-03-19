using System.Web.Mvc;
using System.Web.Routing;

namespace Fullstack.Web.App_Start {
    public class MvcConfig {

        public MvcConfig RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());

            return this;
        }

        public MvcConfig RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { action = "Index", controller = "Pages" }
            );

            return this;
        }

    }
}