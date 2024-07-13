using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; private set; }

        public Category(string name)
        {
            Name = name;
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }
    }
}
