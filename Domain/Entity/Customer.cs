using Domain.Contract.Entity;
using Domain.Events;
using Framework.Events;

namespace Domain.Entity
{
    public class Customer : ICustomer
    {
        #region Properties
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }
        public IEnumerable<IDomainEvent> DomainEvents => domainEvents;
        public bool IsDeleted { get; private set; }
        public Guid Id { get; private set; }

        #endregion

        #region Private
        List<IDomainEvent> domainEvents;
        #endregion

        #region Constructor
        public Customer(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string phoneNumber,
            string email,
            string bankAccountNumber)
        {
            Id = Guid.NewGuid();
            setUp(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

            domainEvents = new();

            var orderCreated = new CustomerCreated()
            {
                BankAccountNumber = BankAccountNumber,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Id = Id
            };

            AddDomainEvent(orderCreated);
        }

        #endregion

        #region Public Methods
        public void AddDomainEvent(IDomainEvent @event)
        {
            domainEvents.Add(@event);
        }

        public void ClearEvents()
        {
            domainEvents.Clear();
        }

        public void RemoveDomainEvent(IDomainEvent @event)
        {
            domainEvents.Remove(@event);
        }

        public void Update(string firstName,
            string lastName,
            DateTime dateOfBirth,
            string phoneNumber,
            string email,
            string bankAccountNumber)
        {
            setUp(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

            AddDomainEvent(
                new CustomerUpdated()
                {
                    BankAccountNumber = BankAccountNumber,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    DateOfBirth = DateOfBirth,
                    Id = Id
                });
        }

        public void Delete()
        {
            IsDeleted = true;

            AddDomainEvent(new CustomerDeleted() { IsDeleted = IsDeleted , Id =Id});
        }

        #endregion

        #region Private Methods
        private void setUp(string firstName,
                        string lastName,
                        DateTime dateOfBirth
                        , string phoneNumber,
                        string email,
                        string bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
        #endregion


    }
}
