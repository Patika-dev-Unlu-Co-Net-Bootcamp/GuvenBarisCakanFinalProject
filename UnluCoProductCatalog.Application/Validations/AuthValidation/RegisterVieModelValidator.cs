using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;

namespace UnluCoProductCatalog.Application.Validations
{
    public class RegisterViewModelValidator :AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email address is required");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(c => c.Password).MinimumLength(8).MaximumLength(20);
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("LastName is required");
        }
    }
}
