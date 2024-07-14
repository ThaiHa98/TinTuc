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
    public class AuthorService : IAuthorIService
    {
        private readonly IRepositoryInterface<Author> _repositoryInterface;
        private readonly MyDBContext _dbContext;
        public AuthorService(IRepositoryInterface<Author> repositoryInterface, MyDBContext dbContext)
        {
            _repositoryInterface = repositoryInterface;
            _dbContext = dbContext;
        }

        public Author CreateAuthor(Author author)
        {
            try
            {
                if (author == null)
                {
                    throw new ArgumentNullException(nameof(author), "The data fields have not been fully entered");
                }
                _repositoryInterface.add(author);
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating author", ex);
            }
        }

        public void DeleteAuthor(int id)
        {
            try
            {
                var authorId = _dbContext.Authors.FirstOrDefault(x => x.Id == id);
                if (authorId == null)
                {
                    throw new Exception("authorId not found");
                }
                _repositoryInterface.remove(id);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred when deleting an Author");
            }
        }

        public IEnumerable<Author> GetAllAuthor()
        {
            return _repositoryInterface.GetAll();
        }

        public Author GetAuthorId(int id)
        {
            try
            {
                var author = _dbContext.Authors.FirstOrDefault(x => x.Id == id);
                if(author == null)
                {
                    throw new Exception("authorId not found");
                }
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurs when getting AuthorId");
            }
        }

        public void UpdateAuthor(Author author)
        {
            try
            {
                var author1 = _dbContext.Authors.FirstOrDefault(x => x.Id == author.Id);
                if (author1 == null)
                {
                    throw new Exception("AuthorId not found");
                }
                author1.Name = author.Name;
                author1.Email = author.Email;
                _repositoryInterface.update(author1);
            }
            catch (Exception ex) 
            {
                throw new Exception("Error Occurred When Updating Author");
            }
        }
    }
}
