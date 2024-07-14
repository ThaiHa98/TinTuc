using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TinTuc.Application.Services.Interface;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Application.Services.Service
{
    public class ArticleService : IArticleIService
    {
        private readonly IRepositoryInterface<Article> _repositoryInterface;
        private readonly MyDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public ArticleService(IRepositoryInterface<Article> repositoryInterface, MyDBContext dbContext, IConfiguration configuration)
        {
            _repositoryInterface = repositoryInterface;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Article CreateArticle(ArticleDto articleDto, IFormFile image)
        {
            try
            {
                if (articleDto == null)
                {
                    throw new ArgumentNullException(nameof(articleDto), "All data fields have not been filled in");
                }

                var author = _dbContext.Authors.FirstOrDefault(x => x.Id == articleDto.AuthorId_Article);
                if (author == null)
                {
                    throw new Exception("authorId not found");
                }

                var category = _dbContext.Categories.FirstOrDefault(x => x.Id == articleDto.CategoryId_Article);
                if (category == null)
                {
                    throw new Exception("CategoryId not found");
                }

                Article article = new Article
                {
                    Name = articleDto.Name_Article,
                    Content = articleDto.Content_Article,
                    AuthorId = author.Id,
                    CategoryId = category.Id
                };

                if (image != null && image.Length > 0)
                {
                    string imagePath = SaveImage(image);
                    article.Image = imagePath;
                }

                _repositoryInterface.add(article);
                return article;
            }
            catch (Exception ex)
            {
                throw new Exception("There is an error when creating an article", ex);
            }
        }


        public void DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticle()
        {
            throw new NotImplementedException();
        }

        public Author GetArticleId(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(ArticleDto articleDto, IFormFile image)
        {
            throw new NotImplementedException();
        }
        private string SaveImage(IFormFile image)
        {
            try
            {
                // Lấy thư mục hiện tại dựa trên ngày tháng
                string currentDateFolder = DateTime.Now.ToString("dd-MM-yyyy");

                // Lấy địa chỉ cơ sở từ cấu hình
                var baseFolder = _configuration["BaseAddressImage"];

                // Tạo đường dẫn thư mục hoàn chỉnh
                string imagesFolder = Path.Combine(baseFolder, currentDateFolder);

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // Tạo tên tệp duy nhất dựa trên GUID và phần mở rộng tệp gốc
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                // Tạo đường dẫn tệp hoàn chỉnh
                string filePath = Path.Combine(imagesFolder, fileName);

                // Lưu tệp vào hệ thống tệp
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // Trả về đường dẫn tương đối
                return Path.Combine(currentDateFolder, fileName);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while saving the image: {ex.Message}");
            }
        }
    }
}
