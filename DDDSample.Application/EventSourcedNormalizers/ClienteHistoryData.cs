using System;

namespace DDDSample.Application.EventSourcedNormalizers
{
    public class ClienteHistoryData
    {
        public string Action { get; set; }

        public Guid ID { get; set; }

        public string Nome { get;  set; }

        public string Idade { get;  set; }

        public string When { get; set; }

        public string Who { get; set; }
    }
}
