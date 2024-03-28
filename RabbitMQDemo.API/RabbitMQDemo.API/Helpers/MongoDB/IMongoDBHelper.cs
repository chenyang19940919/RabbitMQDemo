using MongoDB.Driver;

namespace RabbitMQDemo.API.Helpers.MongoDB
{
    public interface IMongoDBHelper
    {
        public IMongoCollection<T> GetCollection<T>(string name);
    }
}
