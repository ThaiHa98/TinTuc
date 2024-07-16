using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Application.Services.Interface;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Services.Service
{
    public class CategoryService : ICategoryIService
    {
        private readonly MyDBContext _dbContext;
        private readonly IRepositoryInterface<Category> _repositoryInterface;
        public CategoryService(MyDBContext dbContext, IRepositoryInterface<Category> repositoryInterface)
        {
            _dbContext = dbContext;
            _repositoryInterface = repositoryInterface;
        }

        public Category CreateCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category), "The data fields have not been fully entered");
                }
                _repositoryInterface.AddAsync(category);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating category", ex);
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null)
                {
                    throw new Exception("CategoryId not found");
                }
                _repositoryInterface.Remove(id);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while deleting Category");
            }
        }

        public Category GetById(int id)
        {
            try
            {
                var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null)
                {
                    throw new Exception("Id not found");
                }
                return category;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error occurs when gettingCategoryId");
            }
        }

        public IEnumerable<Category> GetCategory()
        {
            return _repositoryInterface.GetAll();
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                var category1 = _dbContext.Categories.FirstOrDefault(x => x.Id == category.Id);
                if (category1 == null)
                {
                    throw new Exception("AuthorId not found");
                }
                category1.Name = category.Name;
                _repositoryInterface.Update(category1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred When Updating Author");
            }
        }
    }
}
