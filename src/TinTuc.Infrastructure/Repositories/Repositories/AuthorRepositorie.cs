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
    public class AuthorRepositorie : IRepositoryInterface<Author>
    {
        private readonly MyDBContext _dbContext;
        public AuthorRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void add(Author entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbContext.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _dbContext.Authors.Find(id);
        }

        public void remove(int Id)
        {
            var author = _dbContext.Authors.Find(Id);
            if (author != null)
            {
                _dbContext.Remove(author);
                _dbContext.SaveChanges();
            }
        }

        public void update(Author entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
