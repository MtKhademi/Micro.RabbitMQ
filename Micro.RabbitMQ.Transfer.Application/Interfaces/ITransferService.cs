using Micro.RabbitMQ.Transfer.Domain.Models;

namespace Micro.RabbitMQ.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransgerLogModel> Gets();

    }
}
