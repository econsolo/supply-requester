using AutoMapper;
using Microsoft.Extensions.Logging;
using SupplyRequester.Business.Services.Interfaces;
using SupplyRequester.Domain.Entities;
using SupplyRequester.Infrastructure.Repositories.Interfaces;
using SupplyRequester.Model.DataTransferObjects;
using System.Threading.Tasks;

namespace SupplyRequester.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IMapper mapper,
            ILoggerFactory loggerFactory,
            IUserRepository userRepository
        ) : base(mapper)
        {
            Logger = loggerFactory.CreateLogger<UserService>();
            _userRepository = userRepository;
        }

        public async Task Add(UserDto userDto)
        {
            var user = Mapper.Map<User>(userDto);

            await _userRepository.Insert(user);
        }
    }
}
