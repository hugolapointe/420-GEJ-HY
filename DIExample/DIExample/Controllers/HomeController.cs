using DIExample.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DIExample.Controllers {
    public class HomeController : Controller {
        private readonly ProductRepository productRepository;

        public HomeController(ProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        public IActionResult Index() {
            productRepository.RemoveProduct("R2D2");

            return RedirectToActionPermanent("Index", "Product");
        }
    }
}