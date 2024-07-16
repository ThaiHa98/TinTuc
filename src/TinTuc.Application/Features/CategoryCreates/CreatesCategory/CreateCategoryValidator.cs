using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Application.Responses;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.CategoryCreates.CreatesCategory
{
    public class CreateCategoryValidator : AbstractValidator<Category>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);
        }
    }
}
