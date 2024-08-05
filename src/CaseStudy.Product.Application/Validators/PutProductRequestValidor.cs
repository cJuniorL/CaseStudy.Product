using CaseStudy.Product.Contracts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Application.Validators;

public class PutProductRequestValidator : ProductModelValidator<PutProductRequest>
{
    public PutProductRequestValidator()
    {
        RuleFor(_ => _.Id).NotEmpty();
    }
}