using AutoMapper;
using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Domain.Models;
using CaseStudy.Product.Domain.Providers;
using CaseStudy.Product.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CaseStudy.Product.Application.UseCases;

public class GetProductUseCase : IUseCase<Guid, GetProductResponse>
{
    private readonly ICacheProvider _cacheProvider;
    private readonly IProductRepository _productRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly ILogger<GetProductUseCase> _logger;

    public GetProductUseCase(
        ICacheProvider cacheProvider,
        IProductRepository productRepository,
        IConfiguration configuration,
        ICancellationTokenAcessor cancellationTokenAcessor,
        IMapper mapper,
        ILogger<GetProductUseCase> logger
    )
    {
        _cacheProvider = cacheProvider;
        _productRepository = productRepository;
        _configuration = configuration;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetProductResponse> ExecuteAsync(Guid request)
    {
        var chaveCache = $"id:{request}";
        var product = _cacheProvider.Get<ProductEntity>(chaveCache);

        if (product is null) 
        {
            product = await _productRepository.GetById(request);
            SetProductInCache(chaveCache, product);
        }

        return _mapper.Map<GetProductResponse>(product);
    }

    private void SetProductInCache(string chaveCache, ProductEntity product)
    {
        if (int.TryParse(_configuration.GetSection("Cache:TimeToExpiration")?.Value, out int timeToExpiration))
            _cacheProvider.Set(chaveCache, product, TimeSpan.FromMinutes(timeToExpiration));
        else
            _logger.LogWarning("Failed to store product in cache. Invalid product ID provided.");
    }
}
