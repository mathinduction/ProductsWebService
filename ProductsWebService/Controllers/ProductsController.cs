using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsWebService.Database;
using ProductsWebService.Database.Entities;

namespace ProductsWebService.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product Get(string id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpPost]
        public void Post([FromBody]Product value)
        {
            _productRepository.SaveProduct(value);
        }
    }
}