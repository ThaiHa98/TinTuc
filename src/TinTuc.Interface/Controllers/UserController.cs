using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TinTuc.Application.Services;
using TinTuc.Application.Services.Service;
using TinTuc.Interface.Common;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("CreateUser")]
        public IActionResult createuser([FromBody] UserDto userdto)
        {
            try
            {
                if (userdto == null)
                {
                    throw new ArgumentNullException(nameof(userdto), "all data fields have not been filled in");
                }

                var user = _userService.CreateUser(userdto);
                return Ok(new XBaseResult
                {
                    data = user,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "create user successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = ex.Message
                });
            }
        }
    }
}
