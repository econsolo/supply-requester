using System.Threading.Tasks;

namespace SupplyRequester.Business.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Validate(string token);
    }
}
