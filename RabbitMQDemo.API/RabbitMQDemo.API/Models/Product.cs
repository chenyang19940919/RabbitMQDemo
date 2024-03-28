using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RabbitMQDemo.API.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

    }
}
