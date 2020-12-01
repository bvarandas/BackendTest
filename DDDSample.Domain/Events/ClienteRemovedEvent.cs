using System;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class ClienteRemovedEvent : Event
    {
        public ClienteRemovedEvent(Guid id)
        {
            ID = id;
            AggregateId = id;
        }

        public Guid ID { get; set; }
    }
}
