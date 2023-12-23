namespace Framework.Events
{
    public interface IDomainEvent
    {
        bool IsDeleted { get; }
    }
}
