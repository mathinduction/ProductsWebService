using Microsoft.AspNetCore.Mvc;
using ProductsWebService.Database;
using ProductsWebService.Database.Entities;
using System.Linq;
using System.Collections.Generic;

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

        /// <summary>
        /// All Products
        /// </summary>
        /// <returns>List of Products</returns>
        /// <response code="200">Returns list of Products</response>
        /// <response code="404">If there is no Products in Database</response>  
        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), (int)System.Net.HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var products = _productRepository.GetAllProducts();
            if (products == null || products.Count() == 0)
                return NotFound();
            return Ok(products);
        }

        /// <summary>
        /// Find Product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Product</returns>
        /// <response code="200">Returns Product with specified Id</response>
        /// <response code="404">If there is no Product with specified Id</response>  
        /// <response code="400">If Id is null</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), (int)System.Net.HttpStatusCode.OK)]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var product = _productRepository.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Add or Edit Product
        /// </summary>
        /// <param name="value">Product to Add or Update</param>
        /// <returns></returns>
        /// <response code="200">Product is Added or Updated</response>
        /// <response code="400">If value is null</response> 
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