using System;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class ClienteRegisteredEvent : Event
    {
        public ClienteRegisteredEvent(Guid id, string nome, int idade)
        {
            ID = id;
            Nome = nome;
            Idade = idade;
            
            AggregateId = id;
        }

        public Guid ID { get; set; }

        public string Nome { get; private set; }

        public int Idade { get; private set; }
    }
}
