using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDDSample.Application.EventSourcedNormalizers;
using DDDSample.Application.Interfaces;
using DDDSample.Application.ViewModels;
using DDDSample.Domain.Commands;
using DDDSample.Domain.Core.Bus;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Repository.EventSourcing;

namespace DDDSample.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _advRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ClienteAppService(IMapper mapper, IClienteRepository advRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _advRepository = advRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return _advRepository.GetAll().ProjectTo<ClienteViewModel>(_mapper.ConfigurationProvider);
        }

        public ClienteViewModel GetById(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(_advRepository.GetByIdInt(id));
        }

        public void Register(ClienteViewModel clienteViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewClienteCommand>(clienteViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ClienteViewModel advViewModel)
        {
            var updateCommand = _mapper.Map<UpdateClienteCommand>(advViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveClienteCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<ClienteHistoryData> GetAllHistory(Guid id)
        {
            return ClienteHistory.ToJavaScriptAdvHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
