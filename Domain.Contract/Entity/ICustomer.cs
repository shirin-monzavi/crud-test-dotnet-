using Domain.Contract.AggregateRoots;

namespace Domain.Contract.Entity
{
    public interface ICustomer:IAggregateRoot<Guid>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string BankAccountNumber { get; }
        public bool IsDeleted { get; }
    }
}
