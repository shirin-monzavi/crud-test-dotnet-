using ApplicationContract.ServiceModels;

namespace ApplicationContract
{
    public interface ICustomerQueryHandler
    {
        Task<CustomerSM> GetCustomerById(Guid id);
    }
}
