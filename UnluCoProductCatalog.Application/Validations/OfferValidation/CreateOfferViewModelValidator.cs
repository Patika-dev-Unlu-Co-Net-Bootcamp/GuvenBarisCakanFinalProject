using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Validations.OfferValidation
{
    public class CreateOfferViewModelValidator : AbstractValidator<CreateOfferViewModel>
    {
        public CreateOfferViewModelValidator()
        {
            RuleFor(o => o.UserId).GreaterThan(0);
            RuleFor(o => o.ProductId).GreaterThan(0);
            RuleFor(o => o.OfferPrice).GreaterThan(0);
        }
    }
}
