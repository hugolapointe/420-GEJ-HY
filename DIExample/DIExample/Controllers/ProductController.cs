using DIExample.Domain.Repositories;
using DIExample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DIExample.Controllers {

    public class ProductController : Controller {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        public IActionResult Index() {
            productRepository.RemoveProduct("WALL-E");
            return Redirect("List");
        }

        public IActionResult List() {
            return View(new ProductListViewModel() {
                AllProducts = productRepository.AllProducts
            });
        }
    }
}
