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
    public class ArticledetailRepositorie : IRepositoryInterface<Articledetail>
    {
        private readonly MyDBContext _dbContext;
        public ArticledetailRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void add(Articledetail entity)
        {
            _dbContext.Articledetails.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Articledetail> GetAll()
        {
            return _dbContext.Articledetails.ToArray();
        }

        public Articledetail GetById(int id)
        {
            return _dbContext.Articledetails.Find(id);
        }

        public void remove(int Id)
        {
            throw new NotImplementedException();
        }

        public void update(Articledetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
