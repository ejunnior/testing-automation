namespace Finance.Infrastructure.Data.UnitOfWork
{
    using System.Threading.Tasks;
    using Domain.Core;
    using Mapping;
    using Microsoft.EntityFrameworkCore;

    public class FinanceUnitOfWork : DbContext, IFinanceUnitOfWork
    {
        public FinanceUnitOfWork(DbContextOptions<FinanceUnitOfWork> options)
            : base(options)
        {
        }

        public async Task CommitAsync()
        {
            await base
                .SaveChangesAsync();
        }

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : AggregateRoot
        {
            return base
                .Set<TEntity>();
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : AggregateRoot
        {
            base.Entry<TEntity>(item)
                .State = EntityState.Modified;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
        }
    }
}