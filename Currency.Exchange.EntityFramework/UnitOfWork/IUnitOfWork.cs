using Currency.Exchange.EntityFramework.Repositories;

namespace Currency.Exchange.EntityFramework.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<T> GetRepository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
