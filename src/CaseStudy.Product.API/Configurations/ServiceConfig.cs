using AutoMapper;
using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Application.Mappers;
using CaseStudy.Product.Application.UseCases;
using CaseStudy.Product.Application.Validators;
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Domain.Providers;
using CaseStudy.Product.Domain.Repositories;
using CaseStudy.Product.Infra.Providers;
using CaseStudy.Product.Infra.Repositories;
using FluentValidation;

namespace CaseStudy.Product.API.Configurations;

public static class ServiceConfig
{
    public static IServiceCollection AddUseCases(this IServiceCollection service)
    {
        service.AddScoped<IUseCase<PostProductRequest, PostProductResponse>, PostProductUseCase>();
        service.AddScoped<IUseCase<Guid, GetProductResponse>, GetProductUseCase>();
        service.AddScoped<IUseCase<PutProductRequest, PutProductResponse>, PutProductUseCase>();

        return service;
    }

    public static IServiceCollection AddMappers(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(ProductMapper));

        return service;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddScoped<IProductRepository, ProductRepository>();

        return service;
    }

    public static IServiceCollection AddValidators(this IServiceCollection service)
    {
        service.AddScoped<IValidator<PostProductRequest>, PostProductRequestValidator>();
        service.AddScoped<IValidator<PutProductRequest>, PutProductRequestValidator>();

        return service;
    }

    public static IServiceCollection AddProviders(this IServiceCollection service)
    {
        service.AddScoped<ICacheProvider, MemoryCacheProvider>();

        return service;
    }
}
