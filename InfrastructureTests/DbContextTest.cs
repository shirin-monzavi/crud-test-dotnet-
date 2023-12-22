using CommonTest;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests
{
    public class DbContextTest : IAsyncDisposable, IDisposable
    {
        private readonly CustomerTestBuilder testBuilder;
        private readonly CustomerDbContext sut;
        public DbContextTest()
        {
            testBuilder = new CustomerTestBuilder();

            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();

            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=CustomerDb3;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

            sut = new CustomerDbContext(optionsBuilder.Options);

            sut.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
        }

        [Fact]
        public async Task Add_Should_Create_Customer()
        {
            //Arrange
            var customerEntity = testBuilder
                                      .WithFirstName(CustomerTestConstants.ANOTHER_FIRSTNAME)
                                .WithLastName(CustomerTestConstants.OTHER_LASTNAME)
                                .WithDateOfBirth(CustomerTestConstants.SOME_DATEOFBIRTH)
                                .WithEmail(CustomerTestConstants.NEW_EMAIL)
                                .WithBankAccountNumber(CustomerTestConstants.ANOTHER_BANKACCOUNTNUMBER)
                                .WithPhoneNumber(CustomerTestConstants.SOME_PHONENUMER)
                .Build();

            await sut.Customers.AddAsync(customerEntity);

            //Act
            var actual = sut.SaveChanges();

            //Assert
            Assert.Equal(1, actual);

        }

        [Fact]
        public async Task Add_Should_ThrowException_When_Customer_Has_Duplicated_Emails()
        {
            //Arrange
            var customerEntity = testBuilder
                                .WithFirstName(CustomerTestConstants.OTHER_FIRSTNAME)
                                .WithLastName(CustomerTestConstants.OTHER_LASTNAME)
                                .WithDateOfBirth(CustomerTestConstants.OTHER_DATEOFBIRTH)
                                .WithEmail(CustomerTestConstants.OTHER_EMAIL)
                                .WithBankAccountNumber(CustomerTestConstants.ANOTHER_BANKACCOUNTNUMBER)
                                .WithPhoneNumber(CustomerTestConstants.SOME_PHONENUMER)
                                .Build();

            await sut.Customers.AddAsync(customerEntity);

            sut.SaveChanges();

            var newCustomerEntity = testBuilder
                    .WithEmail(CustomerTestConstants.OTHER_EMAIL)
                    .Build();

            await sut.Customers.AddAsync(newCustomerEntity);

            //Act

            //Assert
            Assert.ThrowsAny<DbUpdateException>(() => sut.SaveChanges());
        }

        [Fact]
        public async Task Add_Should_ThrowException_When_Customer_Has_Duplicated_FirstName_And_LastName_And_DateOfBirth()
        {
            //Arrange
            var customerEntity = testBuilder
                        .Build();

            await sut.Customers.AddAsync(customerEntity);
            sut.SaveChanges();

            var newCustomerEntity = testBuilder
                   .Build();

            await sut.Customers.AddAsync(newCustomerEntity);
            //Act

            //Assert
            Assert.ThrowsAny<DbUpdateException>(() => sut.SaveChanges());
        }

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }

        public async ValueTask DisposeAsync()
        {
            await sut.Database.EnsureDeletedAsync();
            await sut.DisposeAsync();
        }
    }
}