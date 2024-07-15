using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Infrastructure.Repositories.Repositories
{
    public class UserRepository : IRepositoryInterface<User>
    {
        private readonly MyDBContext _dbContext;

        public UserRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task<User> AddAsync(User entity)
        {
            _dbContext.Users.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Remove(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
