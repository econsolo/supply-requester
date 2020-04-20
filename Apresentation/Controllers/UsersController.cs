using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupplyRequester.Business.Services.Interfaces;
using SupplyRequester.Model.DataTransferObjects;

namespace SupplyRequester.Apresentation.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto userDto)
        {
            await _userService.Add(userDto);

            return ApiResponse();
        }
    }
}