
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Domain.Models;

namespace CaseStudy.Product.Application.Mappers;

public class ProductMapper : AutoMapper.Profile
{
    public ProductMapper() 
    {
        CreateMap<PostProductRequest, ProductEntity>();
        CreateMap<ProductEntity, PostProductResponse>();
        
        CreateMap<ProductEntity, GetProductResponse>();

        CreateMap<PutProductRequest, ProductEntity>();
        CreateMap<ProductEntity, PutProductResponse>();
    }
}
