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
        T GetById(int id);
        void add(T entity);
        void remove(int Id);
        void update(T entity);
    }
}
