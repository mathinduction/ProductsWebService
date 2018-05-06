using Microsoft.EntityFrameworkCore;
using ProductsWebService.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductsWebService.Database
{
    public class MockProductRepository: IProductRepository
    {
        private MockProductDBContext _dbContext;

        public MockProductRepository(MockProductDBContext dbContext)
        {
            _dbContext = dbContext;
            InitMockDB();
        }

        private void InitMockDB()
        {
            _dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE Products");
            _dbContext.Products.Add(new Product() { Id = "0d62fd12-7ce3-4b7f-84cb-b12a417786a2", Name = "product 1", Description = "", Price = 9.99m, ImgUri = "uri" });
            _dbContext.Products.Add(new Product() { Id = "a7c7c58c-c9ae-4179-b278-d702f9c7533d", Name = "product 2", Description = "", Price = 99.99m, ImgUri = "uri" });
            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products;
        }

        public Product GetProduct(string id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SaveProduct(Product product)
        {
            if (product == null)
                return;

            var existingProduct = GetProduct(product.Id);
            if (existingProduct == null)
            {
                _dbContext.Products.Add(product);
            }
            else
            {
                existingProduct.Update(product);
            }
            _dbContext.SaveChanges();
        }

    }
}
