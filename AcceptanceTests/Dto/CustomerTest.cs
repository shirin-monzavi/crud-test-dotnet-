using System.ComponentModel.DataAnnotations;

namespace AcceptanceTests.Dto
{
    public class CustomerTest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public Guid Id { get; set; }
    }
}
