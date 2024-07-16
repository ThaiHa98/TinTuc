using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TinTuc.Domain.Model;
using TinTuc.Domain.PagingRequest;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Infrastructure.Repositories
{
    public class CategoryRepository : IRepositoryInterface<Category>
    {
        private readonly MyDBContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(MyDBContext context)
        {
            _context = context;
            _dbSet = context.Set<Category>();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<Category> AddAsync(Category entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Category GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(Category entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task Remove(Category entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Category entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetPagedAsync(PagingRequestBase request)
        {
            return await _dbSet
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();
        }
    }
}
