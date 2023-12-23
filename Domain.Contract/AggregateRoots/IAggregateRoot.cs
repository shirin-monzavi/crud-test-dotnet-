using Framework.Events;

namespace Domain.Contract.AggregateRoots
{
    public interface IAggregateRoot<TId>
    {
        public TId Id { get; }

        IEnumerable<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent eventItem);

        void ClearEvents();

        void RemoveDomainEvent(IDomainEvent eventItem);
    }
}
