using AutoMapper;
using VideoGameImpressions.Models.Custom;
using VideoGameImpressions.Models.Mongo;

namespace VideoGameImpressions.Configuration
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mongo_VideoGame, VideoGame>();
            CreateMap<VideoGame, Mongo_VideoGame>();
            CreateMap<VideoGameWithNotes, Mongo_VideoGame>();
            CreateMap<Mongo_VideoGame, VideoGameWithNotes>();
            CreateMap<Note, Mongo_Note>();
            CreateMap<Mongo_Note, Note>();
        }
    }
}