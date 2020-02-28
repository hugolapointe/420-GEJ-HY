using Microsoft.AspNetCore.Mvc;

namespace CAExample.Controllers {
    public class PocoController {
        public  IActionResult Index() {
            return new ContentResult() {
                Content = "Hello from POCO Controller."
            };
        }
    }
}
