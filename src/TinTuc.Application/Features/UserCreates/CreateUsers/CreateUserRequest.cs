using MediatR;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.UserCreates.CreateUsers
{
    public class CreateUserRequest : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
