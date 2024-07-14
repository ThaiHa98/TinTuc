using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Services.Interface
{
    public interface ICategoryIService
    {
        IEnumerable<Category> GetCategory();
        Category GetById(int id);
        Category CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
