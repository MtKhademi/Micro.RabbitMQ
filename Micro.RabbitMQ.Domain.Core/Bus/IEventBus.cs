using Micro.RabbitMQ.Domain.Core.Commands;
using Micro.RabbitMQ.Domain.Core.Events;

namespace Micro.RabbitMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<TCommand>(TCommand command) where TCommand : Command;

        void Publish<TEvent>(TEvent @event) where TEvent : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;

    }
}
