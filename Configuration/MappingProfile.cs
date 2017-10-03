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
        }
    }
}