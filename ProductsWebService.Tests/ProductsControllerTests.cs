using ProductsWebService.Controllers;
using ProductsWebService.Database;
using ProductsWebService.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace ProductsWebService.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void GetAllProductsTest()
        {
            var db = new MockProductDBContext();
            var repository = new MockProductRepository(db);
            var controller = new ProductsController(repository);

            var expectedProducts = new List<Product>();
            expectedProducts.Add(new Product() { Id = "0d62fd12-7ce3-4b7f-84cb-b12a417786a2", Name = "product 1", Description = "", Price = 9.99m, ImgUri = "uri" });
            expectedProducts.Add(new Product() { Id = "a7c7c58c-c9ae-4179-b278-d702f9c7533d", Name = "product 2", Description = "", Price = 99.99m, ImgUri = "uri" });

            var result = controller.Get() as ObjectResult;
            var products = result?.Value as IEnumerable<Product>;

            Assert.NotNull(products);
            Assert.True(expectedProducts.SequenceEqual(products));
        }

        [Fact]
        public void GetProductByIdTest()
        {
            var db = new MockProductDBContext();
            var repository = new MockProductRepository(db);
            var controller = new ProductsController(repository);

            var id = "0d62fd12-7ce3-4b7f-84cb-b12a417786a2";
            var expectedProduct = new Product() { Id = id, Name = "product 1", Description = "", Price = 9.99m, ImgUri = "uri" };

            var result = controller.Get(id) as ObjectResult;
            var product = result?.Value as Product;

            Assert.NotNull(product);
            Assert.Equal(expectedProduct, product);
        }

        [Fact]
        public void GetProductByIdNullTest()
        {
            var db = new MockProductDBContext();
            var repository = new MockProductRepository(db);
            var controller = new ProductsController(repository);

            var result = controller.Get("0") as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void AddProductTest()
        {
            var db = new MockProductDBContext();
            var repository = new MockProductRepository(db);
            var controller = new ProductsController(repository);

            var id = Guid.NewGuid().ToString();
            var productToPost = new Product() { Id = id, Name = "product 3", Description = "", Price = 1.00m, ImgUri = "uri" };

            controller.Post(productToPost);
            var result = controller.Get(id) as ObjectResult;
            var product = result?.Value as Product;

            Assert.NotNull(product);
            Assert.Equal(productToPost, product);
        }

        [Fact]
        public void EditProductTest()
        {
            var db = new MockProductDBContext();
            var repository = new MockProductRepository(db);
            var controller = new ProductsController(repository);

            var id = "0d62fd12-7ce3-4b7f-84cb-b12a417786a2";
            var productToPost = new Product() { Id = id, Name = "product 11", Description = "new description", Price = 11.00m, ImgUri = "new uri" };

            controller.Post(productToPost);
            var result = controller.Get(id) as ObjectResult;
            var product = result?.Value as Product;

            Assert.NotNull(product);
            Assert.Equal(productToPost, product);
        }
    }
}
