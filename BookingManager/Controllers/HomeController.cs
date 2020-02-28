using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return RedirectToActionPermanent("Create", "Booking");
        }
    }
}