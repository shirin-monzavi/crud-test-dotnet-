using System.ComponentModel.DataAnnotations;

namespace Crud.Presentation.Server.Models
{
    public class CustomerVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Email is not valid")]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{9,18}$")]
        public string BankAccountNumber { get; set; }
        public Guid Id { get; set; }
    }
}
