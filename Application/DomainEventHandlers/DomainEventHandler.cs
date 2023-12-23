using Domain.Events;
using Microsoft.Extensions.Logging;

namespace Application.DomainEventHandlers
{
    public class DomainEventHandler :
        IDomainEventHandler<CustomerCreated>,
        IDomainEventHandler<CustomerUpdated>,
        IDomainEventHandler<CustomerDeleted>
    {
        private readonly ILogger<DomainEventHandler> logger;

        public DomainEventHandler(ILogger<DomainEventHandler> logger)
        {
            this.logger = logger;
        }

        public void Handle(CustomerCreated @event)
        {
            logger.Log(LogLevel.Information,nameof(CustomerCreated));
        }

        public void Handle(CustomerUpdated @event)
        {
            logger.Log(LogLevel.Information, nameof(CustomerUpdated));
        }

        public void Handle(CustomerDeleted @event)
        {
            logger.Log(LogLevel.Information, nameof(CustomerDeleted));
        }
    }
}
