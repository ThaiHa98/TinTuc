using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using TinTuc.Application.Services;
using TinTuc.Application.Services.Service;
using TinTuc.API.Common;
using TinTuc.ModelDto.ModelDto;
using MediatR;
using TinTuc.Application.Features.User.CreateUser;

namespace TinTuc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "All data fields have not been filled in");
                }

                var response = await _mediator.Send(new CreateUserRequest
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                    Address = request.Address
                });

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
    }
}
