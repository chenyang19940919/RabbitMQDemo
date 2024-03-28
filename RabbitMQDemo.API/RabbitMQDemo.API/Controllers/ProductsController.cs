using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQDemo.API.Models;
using RabbitMQDemo.API.Services.ProductService;

namespace RabbitMQDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) =>
            _productService = productService;

        [HttpGet]
        public async Task<List<Product>> Get() =>
            await _productService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetAsync(id);
            
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product newProduct)
        {
            await _productService.CreateAsync(newProduct);
            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Product updateProduct)
        {
            var product = await _productService.GetAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            updateProduct.Id = product.Id;

            await _productService.UpdateAsync(id, updateProduct);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {

            var product = await _productService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);

            return Ok();
        }

    }
}
