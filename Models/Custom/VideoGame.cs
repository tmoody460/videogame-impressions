using MongoDB.Bson.Serialization.Attributes;

namespace VideoGameImpressions.Models.Custom
{
    public class VideoGame
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
    }
}