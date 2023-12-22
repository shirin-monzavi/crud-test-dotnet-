using Application;
using CommonTest;
using Domain.Contract.Repositories.CustomerQueryRepository;
using NSubstitute;

namespace ApplicationTests
{
    public class CustomerQueryServiceTest
    {
        [Fact]
        public async Task Get_Should_Return_Proper_Customer()
        {
            //Arrenge
            var mockCustomerQueryRepository = Substitute.For<ICustomerQueryRepository>();


            var sut = new CustomerQueryHandler(mockCustomerQueryRepository);

            //Act
            await sut.GetCustomerById(CustomerTestConstants.SOME_ID);

            //Assert
            await mockCustomerQueryRepository.Received(1).GetCustomerById(Arg.Any<Guid>());
        }
    }
}
