using CaseStudy.Product.Application.Abstractions;
using CaseStudy.Product.Contracts.Requests;
using CaseStudy.Product.Contracts.Responses;
using CaseStudy.Product.Contracts.Responses.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CaseStudy.Product.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [ProducesResponseType(typeof(PostProductRequest), (int)HttpStatusCode.Created)]
    [HttpPost("")]
    public async Task<IActionResult> Post(
        [FromBody] PostProductRequest request,
        [FromServices] IUseCase<PostProductRequest, PostProductResponse> useCase)
    {
        var response = await useCase.ExecuteAsync(request);
        return Created($"api/v1/products/{response.Id}", new BaseResponse<PostProductResponse>(response));
        
    }

    [ProducesResponseType(typeof(PostProductRequest), (int)HttpStatusCode.Created)]
    [HttpGet("id")]
    public async Task<IActionResult> GetById(
        Guid id, [FromServices] IUseCase<Guid, GetProductResponse> useCase)
    {
        var response = await useCase.ExecuteAsync(id);
        return Ok(new BaseResponse<GetProductResponse>(response));
    }

    [ProducesResponseType(typeof(PostProductRequest), (int)HttpStatusCode.Created)]
    [HttpPut("id")]
    public async Task<IActionResult> Put(
        Guid id, [FromBody] PutProductRequest request,
        [FromServices] IUseCase<PutProductRequest, PutProductResponse> useCase)
    {
        request.Id = id;
        var response = await useCase.ExecuteAsync(request);
        return Ok(new BaseResponse<PutProductResponse>(response));
    }
}
