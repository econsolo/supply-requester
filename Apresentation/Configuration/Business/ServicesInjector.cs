using Microsoft.Extensions.DependencyInjection;
using SupplyRequester.Business.Services;
using SupplyRequester.Business.Services.Interfaces;

namespace SupplyRequester.Apresentation.Configuration.Business
{
    public static class ServicesInjector
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
