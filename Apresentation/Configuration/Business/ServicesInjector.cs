using Microsoft.Extensions.DependencyInjection;
using SupplyRequester.Business.Services;
using SupplyRequester.Business.Services.Interfaces;

namespace SupplyRequester.Apresentation.Configuration.Business
{
    public static class ServicesInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
