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
    public class CategoryRepositorie : IRepositoryInterface<Category>
    {
        private readonly MyDBContext _dbContext;
        public CategoryRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void add(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void remove(int Id)
        {
            var categories = _dbContext.Categories.FirstOrDefault(x => x.Id == Id);
            if (categories != null)
            {
                _dbContext.Remove(categories);
                _dbContext.SaveChanges();
            }
        }

        public void update(Category entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
