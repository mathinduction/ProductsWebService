using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsWebService.Database.Entities;
using Microsoft.EntityFrameworkCore;

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
            _dbContext.Products.Add(new Product() { Id = Guid.NewGuid().ToString(), Name = "prod 1", Description = "", Price = 9.99m, ImgUri = "uri" });
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
