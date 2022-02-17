using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;

namespace UnluCoProductCatalog.Application.Validations
{
    public class ColorViewModelValidator : AbstractValidator<ColorViewModel>
    {
        public ColorViewModelValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage("Color name is required");
        }
    }
}