using CommonTest;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.CustomerCommandRepository;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests
{
    public class CustomerCommandRepositoryTest :IAsyncDisposable,IDisposable
    {
        private readonly CustomerCommandRepository sut;
        private readonly CustomerTestBuilder testBuilder;
        private readonly CustomerDbContext dbContext;
        public CustomerCommandRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();

            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=CustomerDb1;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

            dbContext = new CustomerDbContext(optionsBuilder.Options);

            dbContext.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
            sut = new CustomerCommandRepository(dbContext);

            testBuilder = new CustomerTestBuilder();
        }

        [Fact]
        public async Task Add_Should_Add_Customer_To_Context()
        {
            //Arrenge
            var customerEntity = testBuilder.Build();

            //Act
            var actual = await sut.Add(customerEntity);

            //Assert
            Assert.NotNull(actual);
        }


        [Fact]
        public async Task Find_Should_Find_Customer_And_Track_It()
        {
            //Arrenge
            var customerEntity = testBuilder.Build();
            var customer = await sut.Add(customerEntity);

            //Act
            var actual = await sut.Find(customer.Id);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task Find_Should_ThrowException_When_Customer_Is_Null()
        {
            //Arrenge

            //Act
            var actual = async () => await sut.Find(CustomerTestConstants.OTHER_ID);

            //Assert
            await Assert.ThrowsAsync<Exception>(actual);
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
