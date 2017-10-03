using AutoMapper;
using MongoDB.Driver;
using VideoGameImpressions.Models.Custom;
using VideoGameImpressions.Models.Mongo;

namespace VideoGameImpressions.DataAccess
{
    public interface IVideoGameAccessor
    {
        VideoGame AddVideoGame(VideoGame game);
        VideoGame GetVideoGame(string id);
    }

    public class VideoGameAccessor : IVideoGameAccessor
    {
        private readonly IVideoGameContext _context;
        private readonly IMapper _mapper;

        public VideoGameAccessor(IVideoGameContext context,
                                 IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VideoGame GetVideoGame(string id)
        {
            var filter = Builders<Mongo_VideoGame>.Filter.Eq("Id", id);
            var mongoGame = _context.VideoGames.Find(filter).FirstOrDefault();
            return _mapper.Map<Mongo_VideoGame, VideoGame>(mongoGame);
        }

        public VideoGame AddVideoGame(VideoGame game)
        {
            var mongoGame = _mapper.Map<VideoGame, Mongo_VideoGame>(game);
            _context.VideoGames.InsertOne(mongoGame);
            return _mapper.Map<Mongo_VideoGame, VideoGame>(mongoGame);
        }
    }
}