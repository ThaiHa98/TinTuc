using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Infrastructure.Repositories.Interface
{
    public interface IRepositoryInterface<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> AddAsync(T entity);
        T GetById(int id);
        void Add(T entity);
        Task Remove(T entity);
        void Update(T entity);
    }
}
