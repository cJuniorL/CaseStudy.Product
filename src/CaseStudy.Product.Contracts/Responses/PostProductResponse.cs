using CaseStudy.Product.Contracts.Model;

namespace CaseStudy.Product.Contracts.Responses;

public class PostProductResponse : ProductModel
{
    public Guid Id { get; set; }
}
