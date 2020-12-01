using System;
using DDDSample.Domain.Core.Commands;

namespace DDDSample.Domain.Commands
{
    public abstract class ClienteCommand :  Command
    {
        public Guid ID { get; protected set; }

        public string Nome { get; protected set; }

        public int Idade { get; protected set; }

        
    }
}
