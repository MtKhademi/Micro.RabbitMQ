using Micro.RabbitMQ.Domain.Core.Bus;
using Micro.RabbitMQ.Transfer.Application.Interfaces;
using Micro.RabbitMQ.Transfer.Domain.Interfaces;
using Micro.RabbitMQ.Transfer.Domain.Models;

namespace Micro.RabbitMQ.Transfer.Application.Services
{
    public class TransferService(
        ITransferLogRepository transferLogRepository,
        IEventBus eventBus) : ITransferService
    {
        public IEnumerable<TransgerLogModel> Gets()
            => transferLogRepository.Gets();

    }
}
