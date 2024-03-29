using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQDemo.API.Models;
using RabbitMQDemo.API.Producer;
using RabbitMQDemo.API.Services.ProductService;

namespace RabbitMQDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public ProductsController(IProductService productService, IRabitMQProducer rabitMQProducer)
        {
            _productService = productService;
            _rabitMQProducer = rabitMQProducer;
        }


        [HttpGet]
        public async Task<List<Product>> Get() =>
            await _productService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product newProduct)
        {
            var product = await _productService.CreateAsync(newProduct);

            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendProductMessage(product);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, Product updateProduct)
        {
            var product = await _productService.GetAsync(id);

            if (product == null)
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
