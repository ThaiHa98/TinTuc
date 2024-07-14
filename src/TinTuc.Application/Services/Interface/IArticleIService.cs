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
    public interface IArticleIService
    {
        IEnumerable<Article> GetAllArticle();
        Author GetArticleId(int id);
        Article CreateArticle(ArticleDto articleDto, IFormFile image);
        void UpdateArticle(ArticleDto articleDto, IFormFile image);
        void DeleteArticle(int id);
    }
}
