using Microsoft.AspNetCore.Mvc;

namespace CAExample.Controllers {
    [ApiController]
    public class ApiController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}