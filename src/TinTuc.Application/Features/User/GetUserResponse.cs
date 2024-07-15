using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Application.Features.User
{
    public record GetUserResponse
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Address { get; init; }
        public DateTime Create { get; init; }
    }
}
