using CommonTest;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.CustomerCommandRepository;
using Infrastructure.Repositories.CustomerQueryRepository;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests
{
    public class CustomerQueryRepositoryTest: IAsyncDisposable, IDisposable
    {

        private readonly CustomerDbContext dbContext;
        private readonly CustomerQueryRepository sut;
        private readonly CustomerTestBuilder testBuilder;
        public CustomerQueryRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();

            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=CustomerDb2;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

            dbContext = new CustomerDbContext(optionsBuilder.Options);

            dbContext.Database.EnsureCreatedAsync().GetAwaiter().GetResult();

            sut = new CustomerQueryRepository(dbContext);

            testBuilder = new CustomerTestBuilder();
        }

        [Fact]
        public async Task GetById_Should_Find_Proper_Customer()
        {
            //Arrenge
            var customerEntity = testBuilder
                           .WithFirstName(CustomerTestConstants.SOME_FIRSTNAME)
                           .WithLastName(CustomerTestConstants.OTHER_FIRSTNAME)
                           .WithDateOfBirth(CustomerTestConstants.OTHER_DATEOFBIRTH)
                           .WithEmail(CustomerTestConstants.NEW_EMAIL)
                           .WithBankAccountNumber(CustomerTestConstants.ANOTHER_BANKACCOUNTNUMBER)
                           .WithPhoneNumber(CustomerTestConstants.ANOTHER_PHONENUMER).Build();

            var customer = dbContext.Customers.Add(customerEntity);
            dbContext.SaveChanges();

            //Act
            var actual = await sut.GetCustomerById(customer.Entity.Id);

            //Assert
            Assert.NotNull(actual);
        }

        public async ValueTask DisposeAsync()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }
    }
}
