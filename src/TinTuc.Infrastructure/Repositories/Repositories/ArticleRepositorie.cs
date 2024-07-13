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

        public void add(Article entity)
        {
            _dbContext.Articles.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Article> GetAll()
        {
            return _dbContext.Articles.ToList();
        }

        public Article GetById(int id)
        {
            return _dbContext.Articles.Find(id);
        }

        public void remove(int Id)
        {
            var article = _dbContext.Articles.Find(Id);
            if (article != null)
            {
                _dbContext.Remove(article);
                _dbContext.SaveChanges();
            }
        }

        public void update(Article entity)
        {
            _dbContext.Articles.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
