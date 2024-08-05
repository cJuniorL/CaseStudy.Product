using CaseStudy.Product.Contracts.Model;
using CaseStudy.Product.Domain.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Application.Validators
{
    public abstract class ProductModelValidator<T>: AbstractValidator<T> where T : ProductModel
    {
        public ProductModelValidator() {
            RuleFor(_ => _.Description).NotEmpty().WithMessage(ProductValidatorErrorMessages.DescriptionCantBeEmpty);
            RuleFor(_ => _.Price).GreaterThan(0).WithMessage(ProductValidatorErrorMessages.PriceLessThanAllowed);
        }
    }
}
