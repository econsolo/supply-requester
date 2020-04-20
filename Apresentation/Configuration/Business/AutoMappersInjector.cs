using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SupplyRequester.Business.AutoMapperProfiles;

namespace SupplyRequester.Apresentation.Configuration.Business
{
    public static class AutoMappersInjector
    {
        public static void InjectMappers(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
