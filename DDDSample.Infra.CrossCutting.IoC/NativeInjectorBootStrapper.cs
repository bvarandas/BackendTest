using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using DDDSample.Infra.CrossCutting.Bus;
using DDDSample.Domain.Core.Bus;

using DDDSample.Application.Interfaces;
using DDDSample.Application.Services;
using DDDSample.Domain.Core.Notifications;
using DDDSample.Domain.Events;
using DDDSample.Domain.EventHandlers;
using DDDSample.Domain.Commands;
using DDDSample.Domain.CommandHandlers;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Repository;
using DDDSample.Infra.Data.UoW;
using DDDSample.Infra.Data.Context;
using DDDSample.Infra.Data.Repository.EventSourcing;
using DDDSample.Domain.Core.Events;
using DDDSample.Infra.Data.EventSourcing;

namespace DDDSample.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void CodeFirst()
        {
            using (BackEndTestContext context = new BackEndTestContext())
            {
                context.Clientes.Add(new Domain.Models.Cliente("Lucinda Gekcs", 28));
                context.Clientes.Add(new Domain.Models.Cliente("Miranda Malis", 32));
                context.Clientes.Add(new Domain.Models.Cliente("Fagner Moura", 17));
                context.Clientes.Add(new Domain.Models.Cliente("Rodolfo Jussso", 39));
                context.Clientes.Add(new Domain.Models.Cliente("Fabio Resende", 55));
                context.Clientes.Add(new Domain.Models.Cliente("Maria Lucia", 29));

                context.SaveChanges();
            }
        }

        public static void RegisterServices(IServiceCollection services)
        {
            // Asp .NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemmoryBus>();
            
            // Application
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<INotificationHandler<ClienteRegisteredEvent>, AdvEventHandler>();
            services.AddScoped<INotificationHandler<ClienteUpdatedEvent>, AdvEventHandler>();
            services.AddScoped<INotificationHandler<ClienteRemovedEvent>, AdvEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, bool>, ClienteCommandHandler>();

            // Infra - Data

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BackEndTestContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

        }
    }
}
