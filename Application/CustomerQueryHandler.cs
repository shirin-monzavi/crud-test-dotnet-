using ApplicationContract;
using ApplicationContract.ServiceModels;
using Domain.Contract.Repositories.CustomerQueryRepository;
using Mapster;

namespace Application
{
    public class CustomerQueryHandler : ICustomerQueryHandler
    {
        private readonly ICustomerQueryRepository customerQueryRepository;

        public CustomerQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            this.customerQueryRepository = customerQueryRepository;
        }

        public async Task<CustomerSM> GetCustomerById(Guid id)
        {
            var customerEntity = await customerQueryRepository
                .GetCustomerById(id).ConfigureAwait(false);

            return customerEntity.Adapt<CustomerSM>();
        }
    }
}
