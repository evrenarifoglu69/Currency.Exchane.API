using Currency.Exchange.EntityFramework.Context;
using Currency.Exchange.EntityFramework.Repositories;

namespace Currency.Exchange.EntityFramework.UnitOfWork
{
    /// <summary>
    /// EntityFramework için oluşturmuş olduğumuz UnitOfWork.
    /// EFRepository'de olduğu gibi bu şekilde tasarlamamızın ana sebebi ise veritabanına independent(bağımsız) bir durumda kalabilmek. Örneğin MongoDB için ise ilgili provider'ı aracılığı ile MongoDBOfWork tasarlayabiliriz.
    /// </summary>
    public class LogUnitOfWork : ILogUnitOfWork
    {
        private readonly LogDbContext _dbContext;

        public LogUnitOfWork(LogDbContext dbContext)
        {
            //Database.SetInitializer<safrandev_sigortacini_dbContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IUnitOfWork Members
        public ILogRepository<T> GetRepository<T>() where T : class
        {
            return new LogRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return await _dbContext.SaveChangesAsync();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }

        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}
