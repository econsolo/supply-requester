using SupplyRequester.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SupplyRequester.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsernamePassword(string username, string password);
        Task<Guid> Insert(User user);
        Task<int> Update(User user);
    }
}
