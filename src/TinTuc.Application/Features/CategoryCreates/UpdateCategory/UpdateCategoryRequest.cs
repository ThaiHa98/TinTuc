using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.CategoryCreates.UpdateCategory
{
    public class UpdateCategoryRequest : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
