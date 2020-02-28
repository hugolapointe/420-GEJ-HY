using System.Collections.Generic;

using DIExample.Domain.Models;

namespace DIExample.Domain.Repositories {
    public interface ProductRepository {
        Product this[string name] { get; }

        IEnumerable<Product> AllProducts { get; }

        void AddProduct(Product product);
        void RemoveProduct(string names);
    }
}