using Micro.RabbitMQ.Domain.Core.Bus;
using Micro.RabbitMQ.Transfer.Domain.Events;
using Micro.RabbitMQ.Transfer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.RabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler(ITransferLogRepository repository) : IEventHandler<TransferCreatedEvent>
    {
        public Task Handle(TransferCreatedEvent @event)
        {
            repository.Add(new Models.TransgerLogModel
            {

                AccountFrom = @event.From,
                AccountTo = @event.To,
                Ammount = @event.Amount,

            });

            return Task.CompletedTask;
        }
    }
}
