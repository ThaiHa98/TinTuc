using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Infrastructure.Repositories.Repositories
{
    public class UserRepositorie : IRepositoryInterface<User>
    {
        private readonly MyDBContext _dbContext;
        public UserRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void remove(int Id)
        {
            var user = _dbContext.Users.Find(Id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public void update(User entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
