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

        public void Add(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task<Category> AddAsync(Category entity)
        {
            _dbContext.Categories.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) 
            {
                throw new Exception("CategoryId not found");
            }
            return category;
        }

        public async Task Remove(Category entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Category entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
