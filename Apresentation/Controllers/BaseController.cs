using Microsoft.AspNetCore.Mvc;
using SupplyRequester.Model.DataTransferObjects;
using System.Net.Mime;

namespace SupplyRequester.Apresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController : ControllerBase
    {
        protected IActionResult ApiResponse(object data = null)
        {
            return Ok(new ApiResponseDto(data));
        }
    }
}
