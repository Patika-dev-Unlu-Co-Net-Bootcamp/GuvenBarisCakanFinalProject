﻿using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace UnluCoProductCatalog.Application.Validations
{
    public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductViewModelValidator()
        {
            RuleFor(p => p.ProductName).MaximumLength(100).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(500).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0).NotEmpty();
            RuleFor(p => p.CategoryName).NotEmpty();
            RuleFor(p => p.UsingStatus).NotEmpty();
        }
    }
}