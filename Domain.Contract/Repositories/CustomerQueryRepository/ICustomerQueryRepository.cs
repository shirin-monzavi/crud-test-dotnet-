using Domain.Contract.Entity;

namespace Domain.Contract.Repositories.CustomerQueryRepository
{
    public interface ICustomerQueryRepository
    {
        Task<ICustomer> GetCustomerById(Guid id);
    }
}
