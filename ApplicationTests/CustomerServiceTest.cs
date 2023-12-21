using Application;
using ApplicationContract;
using ApplicationContract.Commands;
using CommonConstantTest;
using Domain.Contract.Entity;
using Domain.Contract.Repositories.CustomerCommandRepository;
using NSubstitute;

namespace ApplicationTests
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task AddCommand_Should_Create_Customer()
        {
            //Arrenge
            var mockRepository = Substitute.For<ICustomerCommandRepository>();

            var sut = new CustomerCommandHandler(mockRepository);

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
            await mockRepository.Received(1).Add(Arg.Any<ICustomer>());
        }
    }
}