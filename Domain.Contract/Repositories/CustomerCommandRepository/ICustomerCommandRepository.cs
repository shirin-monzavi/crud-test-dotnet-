using Domain.Contract.Entity;

namespace Domain.Contract.Repositories.CustomerCommandRepository
{
    public interface ICustomerCommandRepository
    {
        Task<ICustomer> Add(ICustomer entity);
    }
}
