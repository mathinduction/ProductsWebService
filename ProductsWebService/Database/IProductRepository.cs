using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsWebService.Database.Entities;

namespace ProductsWebService.Database
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string id);
        void SaveProduct(Product product);
    }
}
