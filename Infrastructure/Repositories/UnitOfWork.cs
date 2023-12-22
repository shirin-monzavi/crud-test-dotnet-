using Domain.Contract.Repositories;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext customerDbContext;

        public UnitOfWork(CustomerDbContext customerDbContext)
        {
            this.customerDbContext = customerDbContext;
        }

        public async Task SaveChanges()
        {
           await customerDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
