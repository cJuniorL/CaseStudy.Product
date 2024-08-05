namespace CaseStudy.Product.Application.Abstractions;

public interface IUseCase<TRequest, TResponse>
{
    Task<TResponse> ExecuteAsync(TRequest request);
}

