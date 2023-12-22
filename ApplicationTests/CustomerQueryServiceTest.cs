using Application;
using CommonTest;
using Domain.Contract.Repositories.CustomerQueryRepository;
using NSubstitute;

namespace ApplicationTests
{
    public class CustomerQueryServiceTest
    {
        private readonly ICustomerQueryRepository customerQueryRepositoryMock;
        private readonly CustomerQueryHandler sut;
        public CustomerQueryServiceTest()
        {
            customerQueryRepositoryMock = Substitute.For<ICustomerQueryRepository>();
             sut = new CustomerQueryHandler(customerQueryRepositoryMock);
        }


        [Fact]
        public async Task Get_Should_Return_Proper_Customer()
        {
            //Arrenge

            //Act
            await sut.GetCustomerById(CustomerTestConstants.SOME_ID);

            //Assert
            await customerQueryRepositoryMock.Received(1).GetCustomerById(Arg.Any<Guid>());
        }

        [Fact]
        public async Task GetCustomers_Should_Return_All_Customers()
        {
            //Arrenge

            //Act
            await sut.GetCustomers();

            //Assert
            await customerQueryRepositoryMock.Received(1).GetCustomers();
        }
    }
}
