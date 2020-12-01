using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Events;
using MediatR;

namespace DDDSample.Domain.EventHandlers
{
    public class AdvEventHandler :
        INotificationHandler<ClienteRegisteredEvent>,
        INotificationHandler<ClienteUpdatedEvent>,
        INotificationHandler<ClienteRemovedEvent>
    {
        public Task Handle(ClienteRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }

        public Task Handle(ClienteUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }

        public Task Handle(ClienteRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification

            return Task.CompletedTask;
        }
    }
}
