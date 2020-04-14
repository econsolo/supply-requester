using AutoMapper;
using Microsoft.Extensions.Logging;
using SupplyRequester.Business.Services.Interfaces;

namespace SupplyRequester.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(
            IMapper mapper,
            ILoggerFactory loggerFactory
        ) : base(mapper)
        {
            Logger = loggerFactory.CreateLogger<UserService>();
        }
    }
}
