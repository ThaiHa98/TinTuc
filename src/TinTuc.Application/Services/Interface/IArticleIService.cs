using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Services.Interface
{
    public interface IArticleIService
    {
        IEnumerable<Article> GetAllArticle();
        Author GetArticleId(int id);
        void DeleteArticle(int id);
    }
}
