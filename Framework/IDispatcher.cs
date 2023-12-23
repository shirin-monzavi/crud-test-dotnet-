using Framework.Events;
namespace Framework
{
    public interface IDispatcher
    {
        public void Dispatch<T>(T domainEvent) where T : class, IDomainEvent;
    }
}