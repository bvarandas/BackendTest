using DDDSample.Application.EventSourcedNormalizers;
using DDDSample.Application.ViewModels;
using System;
using System.Collections.Generic;


namespace DDDSample.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        void Register(ClienteViewModel advViewModel);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel GetById(Guid id);
        void Update(ClienteViewModel advViewModel);
        void Remove(Guid id);
        IList<ClienteHistoryData> GetAllHistory(Guid id);
    }
}
