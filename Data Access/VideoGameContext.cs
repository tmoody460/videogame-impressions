using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VideoGameImpressions.Configuration;
using VideoGameImpressions.Models.Mongo;

namespace VideoGameImpressions.DataAccess
{

    public interface IVideoGameContext
    {
        IMongoCollection<Mongo_VideoGame> VideoGames { get; }
    }

    public class VideoGameContext : IVideoGameContext
    {
        private readonly IMongoDatabase _database = null;

        public VideoGameContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null) _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Mongo_VideoGame> VideoGames
        {
            get
            {
                return _database.GetCollection<Mongo_VideoGame>("videogames");
            }
        }
    }
}