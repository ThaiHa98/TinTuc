using MediatR;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.UserCreates.Login
{
    public class LoginRequest : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
