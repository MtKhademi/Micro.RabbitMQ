using MediatR;
using Micro.RabbitMQ.Banking.Domain.Commands;
using Micro.RabbitMQ.Banking.Domain.Events;
using Micro.RabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.RabbitMQ.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler(
        IEventBus eventBus) : IRequestHandler<CreateTransferCommand, bool>
    {
        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {

            eventBus.Publish(new TransferCreatedEvent(
                request.FromAccount,
                request.ToAccount,
                request.Amount)
                );

            return Task.FromResult(true);
        }
    }
}
