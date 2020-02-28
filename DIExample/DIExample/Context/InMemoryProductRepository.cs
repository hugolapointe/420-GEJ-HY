using System.Collections.Generic;
using DIExample.Domain.Models;
using DIExample.Domain.Repositories;

namespace DIExample.Context {
    public class InMemoryProductRepository : ProductRepository {
        private readonly Dictionary<string, Product> products = new Dictionary<string, Product>();

        public InMemoryProductRepository() {
            new List<Product> {
                new Product { Name = "R2D2", Price = 200000M },
                new Product { Name = "WALL-E", Price = 50000M },
                new Product { Name = "RobotCop", Price = 1000000M }
            }.ForEach(p => AddProduct(p));
        }

        public Product this[string name] => products[name];

        public IEnumerable<Product> AllProducts => new List<Product>(products.Values);

        public void AddProduct(Product product) {
            products[product.Name] = product;
        }

        public void RemoveProduct(string name) {
            products.Remove(name);
        }
    }
}
