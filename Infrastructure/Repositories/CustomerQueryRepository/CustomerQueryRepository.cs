using Domain.Contract.Entity;
using Domain.Contract.Repositories.CustomerQueryRepository;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CustomerQueryRepository
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly CustomerDbContext dbContext;
        public CustomerQueryRepository(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICustomer> GetCustomerById(Guid id)
        {
            var entity = await dbContext.Customers
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == id  && x.IsDeleted==false)
                 .ConfigureAwait(false);

            return entity;
        }

        public async Task<IEnumerable<ICustomer>> GetCustomers()
        {
            var entity = await dbContext.Customers
                .AsNoTracking()
                .Where( x=>x.IsDeleted == false)
                .ToListAsync()
                .ConfigureAwait(false);

            return entity;
        }
    }
}
