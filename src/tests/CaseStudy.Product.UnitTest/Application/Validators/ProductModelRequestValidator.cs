using CaseStudy.Product.Application.Validators;
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Domain.Constants;
using CaseStudy.Product.UnitTest.Builders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.UnitTest.Application.Validators
{
    public class ProductModelRequestValidator
    {
        [Fact]
        public void PostProductRequestValidator_Validate_ShouldBeValid()
        {
            var request = new PostProductRequestBuilder().WithDescription("Product").WithPrice(100).Build();

            var validator = new PostProductRequestValidator();
            var result = validator.Validate(request);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void PostProductRequestValidator_Validate_ShouldBeInvalidDescriptionIsEmpty()
        {
            var request = new PostProductRequestBuilder().WithDescription("").WithPrice(100).Build();

            var validator = new PostProductRequestValidator();
            var result = validator.Validate(request);

            var hasError = result.Errors.Select(e => e.ErrorMessage).Contains(ProductValidatorErrorMessages.DescriptionCantBeEmpty);
            Assert.True(hasError);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void PostProductRequestValidator_Validate_ShouldBeInvalidPriceIsLowerThanZero()
        {
            var request = new PostProductRequestBuilder().WithDescription("Product").WithPrice(-1).Build();

            var validator = new PostProductRequestValidator();
            var result = validator.Validate(request);

            var hasError = result.Errors.Select(e => e.ErrorMessage).Contains(ProductValidatorErrorMessages.PriceLessThanAllowed);
            Assert.True(hasError);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void PostProductRequestValidator_Validate_ShouldBeInvalidPriceIsEqualZero()
        {
            var request = new PostProductRequestBuilder().WithDescription("Product").WithPrice(0).Build();

            var validator = new PostProductRequestValidator();
            var result = validator.Validate(request);

            var hasError = result.Errors.Select(e => e.ErrorMessage).Contains(ProductValidatorErrorMessages.PriceLessThanAllowed);
            Assert.True(hasError);
            Assert.False(result.IsValid);
        }
    }
}
