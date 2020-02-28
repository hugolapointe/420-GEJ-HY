using Microsoft.AspNetCore.Mvc;

namespace StripeDemo.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
