using Fullstack.Core.Query;
using System.Web.Http;

namespace Fullstack.Web.Controllers
{
    public class InvoiceController : ApiController
    {
        public IHttpActionResult Get() {
            return this.Ok(new InvoiceQuery().Get());
        }
    }
}
