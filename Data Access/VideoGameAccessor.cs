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
        VideoGameWithNotes GetVideoGameWithNotes(string id);
        VideoGameWithNotes AddVideoGameNote(string id, Note note);
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

        public VideoGame EditVideoGame(VideoGame game)
        {
            var mongoGame = _mapper.Map<VideoGame, Mongo_VideoGame>(game);

            var filter = Builders<Mongo_VideoGame>.Filter.Eq("Id", mongoGame.Id);
            var update = Builders<Mongo_VideoGame>.Update
                                                  .Set(v => v.Name, mongoGame.Name)
                                                  .Set(v => v.Publisher, mongoGame.Publisher);

            var editedGame = _context.VideoGames.FindOneAndUpdate(filter, update);

            return _mapper.Map<Mongo_VideoGame, VideoGame>(editedGame);
        }

        public VideoGameWithNotes AddVideoGameNote(string id, Note note)
        {
            var mongoNote = _mapper.Map<Note, Mongo_Note>(note);

            var filter = Builders<Mongo_VideoGame>.Filter.Eq("Id", id);
            var update = Builders<Mongo_VideoGame>.Update.Push<Mongo_Note>(v => v.Notes, mongoNote);

            var editedGame = _context.VideoGames.FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<Mongo_VideoGame>()
            {
                ReturnDocument = ReturnDocument.After
            });

            return _mapper.Map<Mongo_VideoGame, VideoGameWithNotes>(editedGame);
        }

        public VideoGameWithNotes GetVideoGameWithNotes(string id)
        {
            var filter = Builders<Mongo_VideoGame>.Filter.Eq("Id", id);
            var mongoGame = _context.VideoGames.Find(filter).FirstOrDefault();
            return _mapper.Map<Mongo_VideoGame, VideoGameWithNotes>(mongoGame);
        }
    }
}