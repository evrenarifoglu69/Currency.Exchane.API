using Currency.Exchange.EntityFramework.Repositories;

namespace Currency.Exchange.EntityFramework.UnitOfWork
{
    public interface ILogUnitOfWork : IDisposable
    {
        ILogRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
