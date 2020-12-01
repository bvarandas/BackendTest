using System;
using System.Threading.Tasks;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Events;
using DDDSample.Domain.Core.Commands;
using MediatR;

namespace DDDSample.Infra.CrossCutting.Bus
{
    public class InMemmoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _EventStore;

        public InMemmoryBus(IEventStore eventStorem,IMediator mediator)
        {
            _EventStore = eventStorem;
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T: Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T> (T @event) where T: Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                _EventStore.Save(@event);
            }

            return _mediator.Publish(@event);
        }

    }
}
