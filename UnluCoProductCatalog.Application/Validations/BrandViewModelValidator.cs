using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;

namespace UnluCoProductCatalog.Application.Validations
{
    public class BrandViewModelValidator : AbstractValidator<BrandViewModel>
    {
        public BrandViewModelValidator()
        {
            RuleFor(c => c.BrandName).NotEmpty().WithMessage("Brand name is required");
        }
    }
}