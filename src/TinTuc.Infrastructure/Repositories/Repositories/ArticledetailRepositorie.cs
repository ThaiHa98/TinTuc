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

        public void Add(Articledetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<Articledetail> AddAsync(Articledetail entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Articledetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public Articledetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Articledetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
