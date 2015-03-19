using System.Web.Mvc;

namespace Fullstack.Web.Controllers {
    public class PagesController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}