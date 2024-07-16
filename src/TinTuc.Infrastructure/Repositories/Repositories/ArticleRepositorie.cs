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
    public class ArticleRepositorie : IRepositoryInterface<Article>
    {
        private readonly MyDBContext _dbContext;
        public ArticleRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Article entity)
        {
            throw new NotImplementedException();
        }

        public Task<Article> AddAsync(Article entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}
