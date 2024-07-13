using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Domain.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }

        public Comment(string content, DateTime createdDate, int articleId, int userId)
        {
            Content = content;
            CreatedDate = createdDate;
            ArticleId = articleId;
            UserId = userId;
        }
    }
}
