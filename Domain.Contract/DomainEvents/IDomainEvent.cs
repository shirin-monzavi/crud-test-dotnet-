namespace Domain.Contract.DomainEvents
{
    public interface IDomainEvent
    {
        bool IsDeleted { get; }

    }
}
