using Application;
using ApplicationContract.Commands;
using CommonTest;
using Domain.Contract.Entity;
using Domain.Contract.Repositories;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Framework;
using Framework.Events;
using NSubstitute;

namespace ApplicationTests
{
    public class CustomerCommandServiceTest
    {
        private readonly CustomerCommandHandler sut;
        private readonly ICustomerCommandRepository customerCommandRepositoryMock;
        private readonly IUnitOfWork unitOfWorkMock;
        private readonly IDispatcher dispatcher;
        public CustomerCommandServiceTest()
        {
            customerCommandRepositoryMock = Substitute
                .For<ICustomerCommandRepository>();

            unitOfWorkMock = Substitute.For<IUnitOfWork>();
            dispatcher = Substitute.For<IDispatcher>();


            sut = new CustomerCommandHandler(
                customerCommandRepositoryMock,
                unitOfWorkMock,
                dispatcher
                );
        }

        [Fact]
        public async Task AddCommand_Should_Create_Customer()
        {
            //Arrenge
            var command = new AddCustomerCommand()
            {
                BankAccountNumber = CustomerTestConstants.SOME_BANKACCOUNTNUMBER,
                DateOfBirth = CustomerTestConstants.SOME_DATEOFBIRTH,
                Email = CustomerTestConstants.SOME_EMAIL,
                FirstName = CustomerTestConstants.SOME_FIRSTNAME,
                LastName = CustomerTestConstants.SOME_LASTNAME,
                PhoneNumber = CustomerTestConstants.SOME_PHONENUMER
            };

            //Act
            await sut.AddCommand(command);

            //Assert
            await customerCommandRepositoryMock.Received(1).Add(Arg.Any<ICustomer>());
            await unitOfWorkMock.Received(1).SaveChanges();
        }

        [Fact]
        public async Task UpdateCommand_Should_Update_Customer()
        {
            //Arrenge
            var command = new UpdateCustomerCommand()
            {
                BankAccountNumber = CustomerTestConstants.SOME_BANKACCOUNTNUMBER,
                DateOfBirth = CustomerTestConstants.SOME_DATEOFBIRTH,
                Email = CustomerTestConstants.SOME_EMAIL,
                FirstName = CustomerTestConstants.SOME_FIRSTNAME,
                LastName = CustomerTestConstants.SOME_LASTNAME,
                PhoneNumber = CustomerTestConstants.SOME_PHONENUMER,
                Id = CustomerTestConstants.SOME_ID
            };

            //Act
            await sut.UpdateCommand(command);

            //Assert
            await customerCommandRepositoryMock.Received(1).Find(Arg.Any<Guid>());
            await unitOfWorkMock.Received(1).SaveChanges();

        }

        [Fact]
        public async Task DeleteCommand_Should_Set_Is_Deleted_True_For_Customer()
        {
            //Arrenge
            var command = new DeleteCustomerCommand()
            {
                Id = CustomerTestConstants.SOME_ID
            };

            //Act
            await sut.DeleteCommand(command);

            //Assert
            await customerCommandRepositoryMock.Received(1).Find(Arg.Any<Guid>());
            await unitOfWorkMock.Received(1).SaveChanges();
        }
    }
}