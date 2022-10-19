using Currency.Exchange.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Currency.Exchange.Test.Entities
{
    public partial class TestDbContextMock : CurrencyExchangeDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /**
             * At this stage, a copy of the actual database is created as a memory database.
             * You do not need to create a separate test database.
             */
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }
    }
}
