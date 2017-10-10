using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoGameImpressions.Models.Mongo
{
    public class Mongo_Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }
    }
}