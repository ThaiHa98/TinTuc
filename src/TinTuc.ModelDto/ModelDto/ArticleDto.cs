using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.ModelDto.ModelDto
{
    public class ArticleDto
    {
        public string Name_Article { get; set; }
        public string Content_Article { get; set; }
        public int AuthorId_Article { get; set; }
        public int CategoryId_Article { get; set; }
    }
}
