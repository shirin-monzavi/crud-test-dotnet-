using ApplicationContract;
using ApplicationContract.Commands;
using ApplicationContract.ServiceModels;
using Domain.Contract.Repositories;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Domain.Entity;
using Mapster;

namespace Application
{
    public class CustomerCommandHandler : ICustomerCommandHanlder
    {
        private readonly ICustomerCommandRepository commandRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerCommandHandler(ICustomerCommandRepository commandRepository,
            IUnitOfWork unitOfWork
            )
        {
            this.commandRepository = commandRepository;
            this.unitOfWork = unitOfWork;
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
            unitOfWork.SaveChanges();

            return customerEntity.Adapt<CustomerSM>();
        }

        public async Task UpdateCommand(UpdateCustomerCommand command)
        {

            var customerEntity = await commandRepository.Find(command.Id);

            customerEntity.Update(command.FirstName,
                command.LastName,
                command.DateOfBirth,
                command.PhoneNumber, 
                command.Email, 
                command.BankAccountNumber);

            unitOfWork.SaveChanges();
        }

        public async Task DeleteCommand(DeleteCustomerCommand command)
        {
            var customerEntity = await commandRepository.Find(command.Id);

            customerEntity.Delete();

            unitOfWork.SaveChanges();
        }
    }
}