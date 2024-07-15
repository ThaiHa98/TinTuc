using FluentValidation;

using TinTuc.Application.Responses;

namespace TinTuc.Application.Features.User.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);

            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(StringSizes.Max);
        }
    }
}
