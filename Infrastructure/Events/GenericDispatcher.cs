using Application.DomainEventHandlers;
using Castle.Windsor;
using Domain.Events;

namespace Framework.Events
{
    public class GenericDispatcher : IDispatcher
    {
        private readonly IWindsorContainer container;

        public GenericDispatcher(IWindsorContainer container)
        {
            this.container = container;
        }

        public void Dispatch<T>(T domainEvent) where T : class, IDomainEvent
        {

            if (domainEvent is CustomerCreated)
            {
                var service1 = container.Resolve<IDomainEventHandler<CustomerCreated>>();
                service1.Handle(domainEvent as CustomerCreated);

                return;
            }

            if (domainEvent is CustomerDeleted)
            {
                var service1 = container.Resolve<IDomainEventHandler<CustomerDeleted>>();
                service1.Handle(domainEvent as CustomerDeleted);

                return;
            }

            if (domainEvent is CustomerUpdated)
            {
                var service1 = container.Resolve<IDomainEventHandler<CustomerUpdated>>();
                service1.Handle(domainEvent as CustomerUpdated);

                return;
            }
        }
    }
}