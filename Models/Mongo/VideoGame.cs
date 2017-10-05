using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoGameImpressions.Models.Mongo
{
    public class Mongo_VideoGame
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("publisher")]
        public string Publisher { get; set; }
    }
}