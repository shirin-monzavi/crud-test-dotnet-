using Domain.Entity;

namespace CommonTest
{
    public class CustomerTestBuilder
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string phoneNumber;
        private string email;
        private string bankAccountNumber;
        public Customer sut;
        public CustomerTestBuilder()
        {
            WithAllRequiredFeild();
        }

        public CustomerTestBuilder WithAllRequiredFeild()
        {
            WithFirstName(CustomerTestConstants.SOME_FIRSTNAME);
            WithLastName(CustomerTestConstants.SOME_LASTNAME);
            WithDateOfBirth(CustomerTestConstants.SOME_DATEOFBIRTH);
            WithPhoneNumber(CustomerTestConstants.SOME_PHONENUMER);
            WithEmail(CustomerTestConstants.SOME_EMAIL);
            WithBankAccountNumber(CustomerTestConstants.SOME_BANKACCOUNTNUMBER);

            return this;
        }

        public CustomerTestBuilder WithFirstName(string value)
        {
            firstName = value;
            return this;
        }

        public CustomerTestBuilder WithLastName(string value)
        {
            lastName = value;
            return this;
        }


        public CustomerTestBuilder WithDateOfBirth(DateTime value)
        {
            dateOfBirth = value;
            return this;
        }

        public CustomerTestBuilder WithPhoneNumber(string value)
        {
            phoneNumber = value;
            return this;
        }

        public CustomerTestBuilder WithEmail(string value)
        {
            email = value;
            return this;
        }

        public CustomerTestBuilder WithBankAccountNumber(string value)
        {
            bankAccountNumber = value;
            return this;
        }

        public Customer Build()
        {
            sut = new Customer(
                firstName,
                lastName,
                dateOfBirth,
                phoneNumber,
                email,
                bankAccountNumber);

            return sut;
        }

    }
}
