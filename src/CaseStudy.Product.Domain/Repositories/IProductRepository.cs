using CaseStudy.Product.Domain.Models;

namespace CaseStudy.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> InsertAsync(ProductEntity product, CancellationToken token);
        Task<ProductEntity> GetById(Guid id);
        Task UpdateAsync(ProductEntity product, CancellationToken token);
    }
}
