using Microsoft.AspNetCore.Mvc;

namespace CAExample.Controllers {
    public class MvcController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}