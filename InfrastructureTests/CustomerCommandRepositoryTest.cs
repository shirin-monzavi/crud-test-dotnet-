using CommonTest;
using Domain.Contract.Repositories.CustomerCommandRepository;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.CustomerCommandRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTests
{
    public class CustomerCommandRepositoryTest
    {
        private readonly CustomerTestBuilder testBuilder;
        private readonly CustomerCommandRepository sut;

        public CustomerCommandRepositoryTest()
        {
            testBuilder = new CustomerTestBuilder();

            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();

            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=CustomerDb;Integrated Security=true;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

            var dbContext = new CustomerDbContext(optionsBuilder.Options);

            sut = new CustomerCommandRepository(dbContext);
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
    }
}
