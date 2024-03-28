using RabbitMQDemo.API.Models;

namespace RabbitMQDemo.API.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<Product>> GetAsync();
        public Task<Product> GetAsync(string id);
        public Task CreateAsync(Product newProduct);
        public Task UpdateAsync(string id, Product updateProduct);
        public Task DeleteAsync(string id);
    }
}
