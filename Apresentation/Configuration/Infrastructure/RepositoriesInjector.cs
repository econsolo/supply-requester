using Microsoft.Extensions.DependencyInjection;
using SupplyRequester.Infrastructure.Repositories;
using SupplyRequester.Infrastructure.Repositories.Interfaces;

namespace SupplyRequester.Apresentation.Configuration.Infrastructure
{
    public static class RepositoriesInjector
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
