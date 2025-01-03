using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IProductRepository Products { get; }

    public UnitOfWork(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        Products = productRepository;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Rollback()
    {
        _context.Dispose();
    }
}