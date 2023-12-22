using Domain.Contract.Entity;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories.CustomerCommandRepository
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly CustomerDbContext dbContext;

        public CustomerCommandRepository(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICustomer> Add(ICustomer entity)
        {
            var customer = await dbContext.AddAsync(entity).ConfigureAwait(false);

            return customer.Entity;
        }

        public async Task<ICustomer> Find(Guid id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            return customer;
        }
    }
}
