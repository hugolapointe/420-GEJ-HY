using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICExample.Controllers {

    [Authorize]
    public class ClaimsController : Controller {

        [HttpGet]
        public IActionResult Index() {
            return View(User?.Claims);
        }
    }
}