using Microsoft.Extensions.DependencyInjection;
using SupplyRequester.Business.AutoMapperProfiles;

namespace SupplyRequester.Apresentation.Configuration.Business
{
    public static class AutoMappersInjector
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddSingleton<UserProfile>();
        }
    }
}
