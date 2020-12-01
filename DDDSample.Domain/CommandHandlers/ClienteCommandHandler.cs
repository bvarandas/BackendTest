using System;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Commands;
using System.Text;
using MediatR;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Domain.Models;
using DDDSample.Domain.Events;

namespace DDDSample.Domain.CommandHandlers
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewClienteCommand, bool>,
        IRequestHandler<UpdateClienteCommand, bool>,
        IRequestHandler<RemoveClienteCommand, bool>

    {
        private readonly IClienteRepository _advRepository;
        private readonly IMediatorHandler Bus;

        public ClienteCommandHandler(IClienteRepository advRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _advRepository = advRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            _advRepository.Dispose();
        }

        public Task<bool> Handle(RegisterNewClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var adv = new Cliente(message.Nome, message.Idade);
            
            _advRepository.Add(adv);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteRegisteredEvent(message.ID, message.Nome, message.Idade));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var adv = new Cliente(message.ID, message.Nome, message.Idade);
            
            _advRepository.Update(adv);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteUpdatedEvent(message.ID, message.Nome, message.Idade));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _advRepository.Remove(message.ID);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteRemovedEvent(message.ID));
            }

            return Task.FromResult(true);
        }
    }
}
