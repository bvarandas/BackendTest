using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository :IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
