using Currency.Exchange.Core.DbEntities;
using Currency.Exchange.EntityFramework.Initializer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Currency.Exchange.EntityFramework.Context
{
    public partial class CurrencyExchangeDbContext : IdentityDbContext
    {
        public CurrencyExchangeDbContext()
        {
        }

        public CurrencyExchangeDbContext(DbContextOptions<CurrencyExchangeDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            new CurrencyExchangeDbInitializer(modelBuilder).Seed();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public bool HasChanges => ChangeTracker.HasChanges();
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
        //    {
        //        //switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedOn = DateTime.UtcNow;
        //                entry.Entity.CreatedBy = "1";
        //                entry.Entity.IsDeleted = false;
        //                break;

        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedOn = DateTime.UtcNow; 
        //                entry.Entity.LastModifiedBy = "2";
        //                break;

        //        }
        //    }

        //    //return _authenticatedUser.UserId == null
        //    //    ? await base.SaveChangesAsync(cancellationToken)
        //    //    : await base.SaveChangesAsync(_authenticatedUser.UserId);
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedOn = DateTime.UtcNow;
        //                entry.Entity.CreatedBy = "1";
        //                entry.Entity.IsDeleted = false;
        //                break;

        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedOn = DateTime.UtcNow;
        //                entry.Entity.LastModifiedBy = "2";
        //                break;

        //        }
        //    }

        //    //return _authenticatedUser.UserId == null
        //    //    ? await base.SaveChangesAsync(cancellationToken)
        //    //    : await base.SaveChangesAsync(_authenticatedUser.UserId);
        //    return base.SaveChanges();
        //}
        public DbSet<CurrencyEntity> Currencies { get; set; }
        public DbSet<ExchangeRateEntity> ExchangeRates { get; set; }
        
    }
}
