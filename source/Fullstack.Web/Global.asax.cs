using Fullstack.Core.EntityFramework;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Fullstack.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // don't create a database
            Database.SetInitializer<FullstackContext>(null);
        }
    }
}