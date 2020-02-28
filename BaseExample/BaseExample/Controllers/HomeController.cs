using BaseExample.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace BaseExample.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View(new IndexViewModel());
        }
    }
}