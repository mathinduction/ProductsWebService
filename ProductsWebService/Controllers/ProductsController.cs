using Microsoft.AspNetCore.Mvc;
using ProductsWebService.Database;
using ProductsWebService.Database.Entities;
using System.Linq;

namespace ProductsWebService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetAllProducts();
            if (products == null || products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var product = _productRepository.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            if (value == null)
                return BadRequest();

            _productRepository.SaveProduct(value);
            return Ok();
        }
    }
}