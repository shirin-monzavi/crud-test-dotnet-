﻿using Framework.Events;

namespace Domain.Events
{
    public class CustomerDeleted:IDomainEvent
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
