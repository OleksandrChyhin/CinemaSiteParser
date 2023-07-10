using CinemaSiteParser.Core;
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
