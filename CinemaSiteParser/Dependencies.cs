using CinemaSiteParser.Core;
using CinemaSiteParser.Core.HttpClientService;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaSiteParser
{
    public static class Dependencies
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IHttpClientService, HttpClientService>();            
        }

    }
}
