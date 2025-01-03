namespace Core.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    Task CommitAsync();
    void Rollback();
}
