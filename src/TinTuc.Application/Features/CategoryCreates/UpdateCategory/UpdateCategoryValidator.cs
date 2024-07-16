using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Application.Responses;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.CategoryCreates.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<Category>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);
        }
    }
}
