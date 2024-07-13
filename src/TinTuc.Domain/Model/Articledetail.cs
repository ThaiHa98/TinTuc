using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Domain.Model
{
    public class Articledetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public string Image { get; set; }
    }
}
