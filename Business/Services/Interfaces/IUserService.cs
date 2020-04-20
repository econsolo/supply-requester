using SupplyRequester.Model.DataTransferObjects;
using System.Threading.Tasks;

namespace SupplyRequester.Business.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        Task Add(UserDto userDto);
    }
}
