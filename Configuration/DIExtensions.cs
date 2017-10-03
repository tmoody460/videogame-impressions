using Microsoft.Extensions.DependencyInjection;
using VideoGameImpressions.DataAccess;

namespace VideoGameImpressions.Configuration
{

    public static class DIExtensions
    {
        public static void AddVideoGameSettings(this IServiceCollection services)
        {
            services.AddScoped<IVideoGameContext, VideoGameContext>();
            services.AddScoped<IVideoGameAccessor, VideoGameAccessor>();
        }
    }
}