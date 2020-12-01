using System;
using System.Collections.Generic;
using System.Linq;
using DDDSample.Domain.Core.Events;
using Newtonsoft.Json;

namespace DDDSample.Application.EventSourcedNormalizers
{
    public class ClienteHistory
    {
        public static IList<ClienteHistoryData> HistoryData { get; set; }

        public static IList<ClienteHistoryData> ToJavaScriptAdvHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ClienteHistoryData>();
            AdvHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ClienteHistoryData>();
            var last = new ClienteHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ClienteHistoryData
                {
                    ID = change.ID == last.ID ? Guid.NewGuid() : change.ID,

                    Nome  = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome ? "" : change.Nome,

                    //Modelo = string.IsNullOrWhiteSpace(change.Modelo) || change.Modelo == last.Modelo ? "" : change.Modelo,

                    //Versao = string.IsNullOrWhiteSpace(change.Versao) || change.Versao == last.Versao ? "" : change.Versao,

                    Idade   = string.IsNullOrWhiteSpace(change.Idade) || change.Idade== last.Idade ? "" : change.Idade,

                    //Quilometragem = string.IsNullOrWhiteSpace(change.Quilometragem) || change.Quilometragem == last.Quilometragem ? "": change.Quilometragem,

                    //Observacao = string.IsNullOrWhiteSpace(change.Observacao) || change.Observacao == last.Observacao ? "" : change.Observacao,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,

                    When = change.When,

                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void AdvHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ClienteHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "AdvRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        //slot.Modelo= values["Modelo"];
                        //slot.Versao = values["Versao"];
                        slot.Idade = values["Idade"];
                        //slot.Quilometragem = values["Quilomentragem"];
                        //slot.Observacao = values["Observacao"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.ID = values["ID"];
                        slot.Who = e.User;
                        break;
                    case "AdvUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        //slot.Modelo = values["Modelo"];
                        //slot.Versao = values["Versao"];
                        slot.Idade = values["Idade"];
                        //slot.Quilometragem = values["Quilomentragem"];
                        //slot.Observacao = values["Observacao"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.ID = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "AdvRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.ID = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
