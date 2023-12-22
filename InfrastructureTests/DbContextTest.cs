using CommonTest;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTests
{
    public class DbContextTest
    {
        private readonly CustomerDbContext sut;
        private CustomerTestBuilder testBuilder;
        public DbContextTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();

            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=CustomerDb;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

            testBuilder = new CustomerTestBuilder();

            sut = new CustomerDbContext(optionsBuilder.Options);

            sut.Database.EnsureDeleted();
            sut.Database.EnsureCreated();
        }

        [Fact]
        public async Task Add_Should_Create_Customer()
        {
            //Arrange
            var customerEntity = testBuilder
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
                                .Build();

            await sut.Customers.AddAsync(customerEntity);

            var newCustomerEntity = testBuilder
                .WithFirstName(CustomerTestConstants.ANOTHER_FIRSTNAME)
                .WithLastName(CustomerTestConstants.ANOTHER_LASTNAME)
                .WithDateOfBirth(CustomerTestConstants.ANOTHER_DATEOFBIRTH)
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
                      .WithEmail(CustomerTestConstants.ANOTHER_EMAIL)
                      .Build();

            var nweCustomerEntity = testBuilder
          .WithEmail(CustomerTestConstants.OTHER_EMAIL)
          .Build();

            await sut.Customers.AddAsync(customerEntity);
            await sut.Customers.AddAsync(nweCustomerEntity);

            //Act

            //Assert
            Assert.ThrowsAny<DbUpdateException>(() => sut.SaveChanges());
        }
    }
}