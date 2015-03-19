using Fullstack.Core.Query;
using System.Security.Claims;
using System.Web.Http;

namespace Fullstack.Web.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {
        public IHttpActionResult Get() {
            var user = this.User.Identity as ClaimsIdentity;

            return this.Ok(new InvoiceQuery().Get());
        }
    }
}
