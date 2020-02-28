using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ICExample.Controllers {
    
    [Authorize]
    public class HomeController : Controller {
        
        [HttpGet]
        public IActionResult Index() {
            return View(GetData(nameof(Index)));
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult UserOnly() {
            return View(nameof(Index), GetData(nameof(UserOnly)));
        }

        private Dictionary<string, object> GetData(string actionName) {
            return new Dictionary<string, object> {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In User Role"] = HttpContext.User.IsInRole("User"),
                ["In Admin Role"] = HttpContext.User.IsInRole("Admin")
            };
        }
    }
}