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
    public class CommentRepositorie : IRepositoryInterface<Comment>
    {
        private readonly MyDBContext _dbContext;
        public CommentRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> AddAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
