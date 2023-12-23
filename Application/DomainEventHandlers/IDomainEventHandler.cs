using Framework.Events;

namespace Application.DomainEventHandlers
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
