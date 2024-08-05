using AutoMapper;
using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Contracts.Responses.Base;
using CaseStudy.Product.Domain.Models;
using CaseStudy.Product.Domain.Repositories;
using CaseStudy.Product.Infra.Data;
using FluentValidation;
using MassTransit;
using System.Threading;

namespace CaseStudy.Product.Application.UseCases;

public class PostProductUseCase : IUseCase<PostProductRequest, PostProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IValidator<PostProductRequest> _validator;
    private readonly IProductRepository _productRepository;
    private readonly ICancellationTokenAcessor _cancellationTokenAcessor;
    private readonly ITopicProducer<ProductEntity> _producer;

    public PostProductUseCase(
        IMapper mapper, 
        IValidator<PostProductRequest> validator,
        IProductRepository productRepository, 
        ICancellationTokenAcessor cancellationTokenAcessor,
        ITopicProducer<ProductEntity> producer)
    {
        _mapper = mapper;
        _validator = validator;
        _productRepository = productRepository;
        _cancellationTokenAcessor = cancellationTokenAcessor;
        _producer = producer;
    }

    public async Task<PostProductResponse> ExecuteAsync(PostProductRequest request)
    {
        _validator.ValidateAndThrow(request);

        var produto = _mapper.Map<ProductEntity>(request);

        await _productRepository.InsertAsync(produto, _cancellationTokenAcessor.Token);
        await _producer.Produce(produto, _cancellationTokenAcessor.Token);

        var response = _mapper.Map<PostProductResponse>(produto);
        return response;
    }
}
