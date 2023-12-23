using ApplicationContract.Commands;
using ApplicationContract.ServiceModels;

namespace ApplicationContract
{
    public interface ICustomerCommandHanlder
    {
        Task<CustomerSM> AddCommand(AddCustomerCommand command);

        Task UpdateCommand(UpdateCustomerCommand command);

        Task DeleteCommand(DeleteCustomerCommand command);
    }
}