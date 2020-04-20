using AutoMapper;
using SupplyRequester.Business.Services.Interfaces;
using System.Threading.Tasks;

namespace SupplyRequester.Business.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(
            IMapper mapper
        ) : base(mapper)
        {
        }

        public async Task<bool> Validate(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
