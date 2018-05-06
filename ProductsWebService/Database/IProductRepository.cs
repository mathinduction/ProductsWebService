using ProductsWebService.Database.Entities;
using System.Collections.Generic;

namespace ProductsWebService.Database
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string id);
        void SaveProduct(Product product);
    }
}
