using System.Collections.Generic;

using DIExample.Domain.Models;

namespace DIExample.ViewModels {
    public class ProductListViewModel {
        public IEnumerable<Product> AllProducts { get; set; }
    }
}
