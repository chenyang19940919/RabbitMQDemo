using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RabbitMQDemo.API.Helpers.MongoDB
{
    public class MongoDBHelper: IMongoDBHelper
    {
        private readonly IMongoDatabase _database;

        public MongoDBHelper(IOptionsMonitor<MongoDBSettings> options)
        {
            var mongoClient = new MongoClient(options.CurrentValue.ConnectionString);
            _database = mongoClient.GetDatabase(options.CurrentValue.DatabaseName);
        }

        /// <summary>
        /// Get Collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
