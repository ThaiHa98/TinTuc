using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TinTuc.API.Common;
using MediatR;
using TinTuc.Application.Features.UserCreates.CreateUsers;
using TinTuc.Application.Features.UserCreates.Login;
using TinTuc.Application.Features.UserCreates.Logout;
using TinTuc.Application.Helper;

namespace TinTuc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Token _token;

        public UserController(IMediator mediator, Token token)
        {
            _token = token;
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (request == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "All data fields have not been filled in"
                });
            }

            try
            {
                var response = await _mediator.Send(request);

                return Ok(new XBaseResult
                {
                    data = response,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Create user successfully"
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

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
        {
            if(request == null)
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "All data fields have not been filled in"
                });
            }
            try
            {
                var response = await _mediator.Send(request);

                return Ok(new XBaseResult
                {
                    data = response,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Login successfully"
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

        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutUser()
        {
            // Lấy thông tin người dùng từ HttpContext
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "User not found or invalid user ID"
                });
            }

            try
            {
                // Gửi yêu cầu LogoutRequest tới MediatR
                var response = await _mediator.Send(new LogoutRequest { Id = userId });

                return Ok(new XBaseResult
                {
                    data = response,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Logout successfully"
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
