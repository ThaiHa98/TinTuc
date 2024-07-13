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
    public class CommentRepositorie : IRepositoryInterface<Comment>
    {
        private readonly MyDBContext _dbContext;
        public CommentRepositorie(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void add(Comment entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return _dbContext.Comments.Find(id);
        }

        public void remove(int Id)
        {
            var comments = _dbContext.Comments.Find(Id);
            if (comments != null)
            {
                _dbContext.Remove(comments);
                _dbContext.SaveChanges();
            }
        }

        public void update(Comment entity)
        {
            _dbContext.Comments.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
