using AutoMapper;
using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Domain.Models;
using CaseStudy.Product.Domain.Providers;
using CaseStudy.Product.Domain.Repositories;
using FluentValidation;

namespace CaseStudy.Product.Application.UseCases;

public class PutProductUseCase : IUseCase<PutProductRequest, PutProductResponse>
{
    private readonly ICacheProvider _cacheProvider;
    private readonly IProductRepository _productRepository;
    private readonly IValidator<PutProductRequest> _validator;
    private readonly ICancellationTokenAcessor _cancellationTokenAcessor;
    private readonly IMapper _mapper;
    
    public PutProductUseCase(
        ICacheProvider cacheProvider,
        IProductRepository productRepository,
        IMapper mapper,
        ICancellationTokenAcessor cancellationTokenAcessor,
        IValidator<PutProductRequest> validator
    ) 
    {
        _cacheProvider = cacheProvider;
        _productRepository = productRepository;
        _validator = validator;
        _cancellationTokenAcessor = cancellationTokenAcessor;
        _mapper = mapper;
    }


    public async Task<PutProductResponse> ExecuteAsync(PutProductRequest request)
    {
        _validator.Validate(request);

        var product = _mapper.Map<ProductEntity>(request);
            
        if (product is not null)
        {
            await _productRepository.UpdateAsync(product, _cancellationTokenAcessor.Token);
            _cacheProvider.Delete($"id:{product.Id}");
        }
        else
            throw new ArgumentException("The targeted product identifier does not exist");

        return _mapper.Map<PutProductResponse>(product);
    }
}
