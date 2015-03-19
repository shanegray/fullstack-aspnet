using Fullstack.Core.DbModels;
using Fullstack.Core.Identity;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;


namespace Fullstack.Web.Controllers {
    public class AccountController : ApiController {        

        [HttpPost]
        public IHttpActionResult Post(User user) {
            var userManager = Request.GetOwinContext().GetUserManager<UserManager>();

            var result = userManager.CreateAsync(user).Result;

            return this.Ok();
        }
    }
}
