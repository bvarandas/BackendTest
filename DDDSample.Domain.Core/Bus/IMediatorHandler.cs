using System.Threading.Tasks;
using DDDSample.Domain.Core.Commands;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
