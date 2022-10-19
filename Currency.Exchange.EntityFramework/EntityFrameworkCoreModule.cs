using Currency.Exchange.EntityFramework.Context;
using Currency.Exchange.EntityFramework.Repositories;
using Currency.Exchange.EntityFramework.UnitOfWork;
using Currency.Exchange.Shared.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Currency.Exchange.EntityFramework
{
    public static class EntityFrameworkCoreModule
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient(typeof(ILogRepository<>), typeof(LogRepository<>));
            services.AddTransient<ILogUnitOfWork, UnitOfWork.LogUnitOfWork>();

            services.AddDbContext<CurrencyExchangeDbContext>(options => options.UseSqlServer(StaticValues.CurrencyExchange_MsSql_ConStr), ServiceLifetime.Transient);
            services.AddDbContext<LogDbContext>(options => options.UseSqlServer(StaticValues.CurrencyExchange_Log_MsSql_ConStr), ServiceLifetime.Transient);
        }
    }
}
