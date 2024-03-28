using MongoDB.Driver;
using RabbitMQDemo.API.Helpers.MongoDB;
using RabbitMQDemo.API.Models;

namespace RabbitMQDemo.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMongoDBHelper mongoDBHelper)
        {
            _productCollection = mongoDBHelper.GetCollection<Product>("Product");
        }

        public async Task<List<Product>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();

        public async Task<Product> GetAsync(string id) =>
            await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product newProduct) =>
            await _productCollection.InsertOneAsync(newProduct);

        public async Task UpdateAsync(string id, Product updateProduct) =>
            await _productCollection.ReplaceOneAsync(x => x.Id == id, updateProduct);

        public async Task DeleteAsync(string id) =>
            await _productCollection.DeleteOneAsync(x => x.Id == id);
    }
}
