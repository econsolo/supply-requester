using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SupplyRequester.Model.DataTransferObjects;
using SupplyRequester.Model.Validators;

namespace SupplyRequester.Apresentation.Configuration.Model
{
    public static class ValidatorsInjector
    {
        public static void InjectValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserDto>, UserDtoValidator>();
        }
    }
}
