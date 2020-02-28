using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}