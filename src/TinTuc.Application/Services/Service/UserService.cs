using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TinTuc.Application.Helper;
using TinTuc.Application.Services.Interface;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Application.Services.Service
{
    public class UserService : IUserIService
    {
        private readonly IRepositoryInterface<User> _repositoryInterface;
        private readonly MyDBContext _dbContext;
        private readonly Token _token;
        public UserService(IRepositoryInterface<User> repositoryInterface, MyDBContext myDBContext, Token token)
        {
            _dbContext = myDBContext;
            _token = token;
            _repositoryInterface = repositoryInterface;
        }

        public User CreateUser(UserDto userDto)
        {
            if(userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto), "Account data has not been filled in completely");
            }
            User user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Address = userDto.Address,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };
            _repositoryInterface.add(user);
            return user;
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserId(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("Id not found");
            }
            return user;
        }

        public string Login(LoginRequestDto loginRequestDto, HttpContext context)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Email == loginRequestDto.Email);
                if (user == null)
                {
                    throw new Exception("Email not found");
                }

                if (!BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.Password))
                {
                    throw new Exception("Incorrect password!");
                }

                // Tạo token cho người dùng
                string token = _token.CreateToken(user);

                // Lưu token vào cookies
                CookieOptions options = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddMinutes(60) // Thời gian hết hạn của cookie
                };
                context.Response.Cookies.Append("authenticationToken", token, options);

                return token; // Trả về token cho phương thức gọi
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in");
            }
        }


        public bool Logout(int Id, HttpContext context)
        {
            try
            {
                //lấy token từ cookies
                if (!context.Request.Cookies.TryGetValue("authenticationToken", out var token))
                {
                    throw new Exception("Token not found in cookies");
                }
                //Xác thực token
                if (!_token.ValidateToken(token))
                {
                    throw new Exception("Invalid token");
                }
                //lấy thông tin người dùng từ token
                var principal = _token.GetPrincipalFromToken(token);
                var tokenUserId = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (tokenUserId != Id) 
                {
                    throw new Exception("Token does not match the user Id");
                }

                //xóa token khỏi cookies
                context.Response.Cookies.Delete("authenticationToken");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Logout failed", ex);
            }
        }

        public string ResetPassword(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
