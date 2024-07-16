using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.UserCreates.Logout
{
    public class LogoutRequest : IRequest<string>
    {
        public int Id { get; set; }
    }
}
