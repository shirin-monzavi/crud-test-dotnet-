using CommonConstantTest;
using Domain.Entity;
using FluentAssertions;

namespace DomainTests
{
    public class CustomerTest
    {
        private CustomerTestBuilder testBuilder;
        private Customer sut;

        public CustomerTest()
        {
            testBuilder = new CustomerTestBuilder();
        }

        [Fact]
        public void Constructor_Should_Create_Customer_With_Required_Feilds()
        {
            //Arrenge
            sut = testBuilder
                .Build();

            //Act

            //Assert
            Assert.NotNull(sut);
            sut.Should().BeEquivalentTo(testBuilder.sut);
           sut.DomainEvents.Should().HaveCount(1);
        }

        [Fact]
        public void Update_Should_Modify_The_Sepecified_Feilds()
        {
            //Arrenge
            sut = testBuilder
                .Build();

            var expectedSut = testBuilder
                .WithFirstName(CustomerTestConstants.ANOTHER_FIRSTNAME)
                .WithLastName (CustomerTestConstants.ANOTHER_LASTNAME)
                .Build();

            //Act
            sut.Update(expectedSut.FirstName,
            expectedSut.LastName,
            expectedSut.DateOfBirth,
            expectedSut.PhoneNumber,
            expectedSut.Email,
            expectedSut.BankAccountNumber);


            //Assert
            Assert.NotNull(expectedSut);
            expectedSut.Should().BeEquivalentTo(testBuilder.sut);
            sut.DomainEvents.Should().HaveCount(2);
        }

        [Fact]
        public void Delete_Should_Set_Is_Deleted_True()
        {
            //Arrenge
            sut = testBuilder
                .Build();

            //Act
            sut.Delete();


            //Assert
            Assert.True(sut.IsDeleted);
            sut.DomainEvents.Should().HaveCount(2);
        }
    }
}