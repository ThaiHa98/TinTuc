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

        public void Add(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<Author> AddAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
