using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Validations.OfferValidation
{
    public class UpdateOfferViewModelValidator : AbstractValidator<UpdateOfferViewModel>
    {
        public UpdateOfferViewModelValidator()
        {
            RuleFor(o => o.UserId).GreaterThan(0);
            RuleFor(o => o.ProductId).GreaterThan(0);
            RuleFor(o => o.OfferPrice).GreaterThan(0);
        }
    }
}
