using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TinTuc.Domain.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }

        public Article(string name, string content, DateTime publishedDate, int authorId, int categoryId, string image)
        {
            Name = name;
            Content = content;
            PublishedDate = publishedDate;
            AuthorId = authorId;
            CategoryId = categoryId;
            Image = image;
        }
    }
}
