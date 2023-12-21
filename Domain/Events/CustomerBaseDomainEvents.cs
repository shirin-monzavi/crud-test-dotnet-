﻿using Domain.Contract.DomainEvents;

namespace Domain.Events
{
    public class CustomerBaseDomainEvents:IDomainEvent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
