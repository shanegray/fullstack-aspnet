using Fullstack.Core.EntityFramework;
using Fullstack.Web.App_Start;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fullstack.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            new MvcConfig()
                .RegisterRoutes(RouteTable.Routes)
                .RegisterGlobalFilters(GlobalFilters.Filters);

            // don't create a database
            Database.SetInitializer<FullstackContext>(null);
        }
    }
}