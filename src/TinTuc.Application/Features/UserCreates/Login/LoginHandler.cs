using MediatR;
using Microsoft.AspNetCore.Http;
using TinTuc.Application.Helper;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace TinTuc.Application.Features.UserCreates.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly IRepositoryInterface<User> _repositoryInterface;
        private readonly MyDBContext _dbContext;
        private readonly Token _token;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginHandler(
            IRepositoryInterface<User> repositoryInterface,
            MyDBContext myDBContext,
            Token token,
            IHttpContextAccessor httpContextAccessor)
        {
            _repositoryInterface = repositoryInterface;
            _dbContext = myDBContext;
            _token = token;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request), "The request has not been filled in with enough data");
                }

                var user = _dbContext.Users.FirstOrDefault(x => x.Email == request.Email);
                if (user == null)
                {
                    throw new Exception("Email not found");
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    throw new Exception("Incorrect password!");
                }

                // Tạo token cho người dùng
                string token = _token.CreateToken(user);

                var context = _httpContextAccessor.HttpContext;
                if (context != null)
                {
                    CookieOptions cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTime.Now.AddMinutes(60)
                    };
                    context.Response.Cookies.Append("authenticationToken", token, cookieOptions);
                }

                return await Task.FromResult(token);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while logging in", ex);
            }
        }
    }
}
