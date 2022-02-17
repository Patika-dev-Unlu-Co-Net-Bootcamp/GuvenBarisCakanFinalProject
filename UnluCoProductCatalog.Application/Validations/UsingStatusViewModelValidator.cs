using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;

namespace UnluCoProductCatalog.Application.Validations
{
    public class UsingStatusViewModelValidator : AbstractValidator<UsingStatusViewModel>
    {
        public UsingStatusViewModelValidator()
        {
            RuleFor(c => c.UsingStatusName).NotEmpty().WithMessage("UsingStatusName name is required");
        }
    }
}