using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Application.Services.Interface
{
    public interface IAuthorIService
    {
        IEnumerable<Author> GetAllAuthor();
        Author GetAuthorId(int id);
        Author CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}
