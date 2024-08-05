using CaseStudy.Product.Contracts.Model;
using CaseStudy.Product.Contracts.Requests;
using FluentValidation;

namespace CaseStudy.Product.Application.Validators;

public class PostProductRequestValidator : ProductModelValidator<PostProductRequest>
{
    public PostProductRequestValidator()
    {
    }
}
