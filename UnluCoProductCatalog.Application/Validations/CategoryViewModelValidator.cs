using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;

namespace UnluCoProductCatalog.Application.Validations
{
    public class CategoryViewModelValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryViewModelValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Category name is required");
        }
    }
}
