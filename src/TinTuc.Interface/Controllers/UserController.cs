using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
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
        public IActionResult CreateUser([FromBody] UserDto userdto)
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

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                if(loginRequestDto == null)
                {
                    throw new Exception("Email and Password have not been entered");
                }
                var user = _userService.Login(loginRequestDto, HttpContext);

                //Cập nhật thời gian cuối cùng sau khi đăng nhập thành công
                CookieOptions options = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddMinutes(3)
                };
                HttpContext.Response.Cookies.Append("LastActivityTime", DateTime.Now.ToString(), options);

                return Ok(new XBaseResult
                {
                    data = user,
                    success = true,
                    httpStatusCode = (int)HttpStatusCode.OK,
                    message = "Login Successfully"
                });
            }
            catch(Exception ex)
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
        public IActionResult Logout()
        {
            try
            {
                //lấy thông tin người dùng từ token
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if(userIdClaim != null && int.TryParse(userIdClaim.Value, out int id))
                {
                    //gọi phương thức logout
                    if (_userService.Logout(id, HttpContext))
                    {
                        return Ok(new XBaseResult
                        {
                            success = false,
                            httpStatusCode = (int)HttpStatusCode.OK,
                            message = "Login Successfully"
                        });
                    }
                }
                return BadRequest(new XBaseResult
                {
                    success = false,
                    httpStatusCode = (int)HttpStatusCode.BadRequest,
                    message = "Logout failed"
                });
            }
            catch(Exception ex)
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
