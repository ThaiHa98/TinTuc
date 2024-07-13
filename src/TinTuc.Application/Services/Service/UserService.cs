using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Application.Services.Interface;
using TinTuc.Domain.Model;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Application.Services.Service
{
    public class UserService : IUserIService
    {
        public User CreateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public User GetUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
