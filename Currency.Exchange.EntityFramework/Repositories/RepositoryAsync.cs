using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Currency.Exchange.EntityFramework.Context;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Currency.Exchange.Core.BaseEntities;

namespace Currency.Exchange.EntityFramework.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RepositoryAsync(CurrencyExchangeDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _httpContextAccessor = httpContextAccessor;
        }
        //public IQueryable<T> Entities => _dbContext.Set<T>();

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }


        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public IQueryable<T> GetThenIncluding(List<Func<IQueryable<T>, IQueryable<T>>> funcs, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            foreach (var func in funcs)
            {
                query = func(query);
            }
            return query;
        }

        public IQueryable<T> IQueryable()
        {
            IQueryable<T> query = _dbSet;
            return query;
        }

        //public IEnumerable<T> GetThenIncluding(Func<IQueryable<T>, IQueryable<T>> func)
        //{
        //    IQueryable<T> query = _dbSet;
        //    IQueryable<T> result = func(query);
        //    return result;
        //}

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {

            if (typeof(IAuditableBaseEntity).IsAssignableFrom(typeof(T)))
            {
                IAuditableBaseEntity _entity = (IAuditableBaseEntity)entity;

                _entity.IsDeleted = true;

                this.UpdateAsync((T)_entity);
            }
            else if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                this.UpdateAsync(_entity);
            }
            else
            {
                // Önce entity'nin state'ini kontrol etmeliyiz.
                EntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            if (typeof(IAuditableBaseEntity).IsAssignableFrom(typeof(T)))
            {
                IAuditableBaseEntity _entity = (IAuditableBaseEntity)entity;

                _entity.LastModifiedOn = DateTime.Now;
                _entity.LastModifiedBy = string.Empty;

                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = identity.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                    _entity.LastModifiedBy = !string.IsNullOrEmpty(userId) ? userId : string.Empty;
                }
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public async Task<T> AddAuditableAsync(T entity)
        {
            if (typeof(IAuditableBaseEntity).IsAssignableFrom(typeof(T)))
            {
                IAuditableBaseEntity _entity = (IAuditableBaseEntity)entity;

                _entity.CreatedOn = DateTime.Now;
                _entity.CreatedBy = string.Empty;

                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = identity.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                    _entity.CreatedBy = !string.IsNullOrEmpty(userId) ? userId : string.Empty;
                }

                await this.AddAsync((T)_entity);
                return (T)_entity;
            }
            else
            {
                await this.AddAsync(entity);
                return entity;
            }

        }
    }
}
