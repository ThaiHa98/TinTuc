using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Application.Services.Interface
{
    public interface IUserIService
    {
        IEnumerable<User> GetAllArticles();
        User GetUserId(int id);
        User CreateUser(UserDto userDto);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
