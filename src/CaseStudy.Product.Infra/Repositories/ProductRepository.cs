using CaseStudy.Product.Domain.Models;
using CaseStudy.Product.Domain.Repositories;
using CaseStudy.Product.Infra.Data;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CaseStudy.Product.Infra.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ProductDbContext _context;
    public ProductRepository(ProductDbContext context) 
    {
        _context = context;
    }

    public async Task<ProductEntity> GetById(Guid id)
    {
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id);
        return product;
    }

    public async Task<ProductEntity> InsertAsync(ProductEntity product, CancellationToken token)
    {
        await _context.Products.AddAsync(product, token);
        await _context.SaveChangesAsync(token);

        return product;
    }

    public async Task UpdateAsync(ProductEntity product, CancellationToken token)
    {
        //_context.Products.Attach(product);
        //_context.Products.Update(product);
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync(token);
    }
}
