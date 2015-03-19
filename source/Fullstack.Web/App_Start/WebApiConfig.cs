using System.Web.Http;

namespace Fullstack.Web
{
    public class WebApiConfig
    {
        private readonly HttpConfiguration config;
        public WebApiConfig(HttpConfiguration config) {
            this.config = config;
        }

        public WebApiConfig RegisterRoutes()
        {
            this.config.MapHttpAttributeRoutes();

            this.config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return this;
        }

        public WebApiConfig ConfigureFormatters() {
            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return this;
        }
    }
}
