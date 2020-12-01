using DDDSample.Domain.Core.Events;
using DDDSample.Domain.Interfaces;
using DDDSample.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace DDDSample.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
            //_user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "UsuarioLogado");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
