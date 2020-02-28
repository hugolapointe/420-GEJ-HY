using Microsoft.AspNetCore.Mvc;

namespace VCExample.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return RedirectToAction("Index", "ToDo");
        }
    }
}