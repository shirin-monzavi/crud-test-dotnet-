using ApplicationContract;
using ApplicationContract.Commands;
using ApplicationContract.ServiceModels;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Domain.Entity;
using Mapster;

namespace Application
{
    public class CustomerCommandHandler : ICustomerCommandHanlder
    {
        private readonly ICustomerCommandRepository commandRepository;

        public CustomerCommandHandler(ICustomerCommandRepository commandRepository)
        {
            this.commandRepository = commandRepository;
        }

        public async Task<CustomerSM> AddCommand(AddCustomerCommand command)
        {
            var customer = new Customer(
                command.FirstName,
                command.LastName,
                command.DateOfBirth,
                command.PhoneNumber,
                command.Email,
                command.BankAccountNumber);

            var customerEntity = await commandRepository.Add(customer);

            return customerEntity.Adapt<CustomerSM>();
        }
    }
}