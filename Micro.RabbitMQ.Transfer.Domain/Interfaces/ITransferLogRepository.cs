using Micro.RabbitMQ.Transfer.Domain.Models;

namespace Micro.RabbitMQ.Transfer.Domain.Interfaces
{
    public interface ITransferLogRepository
    {
        IEnumerable<TransgerLogModel> Gets();

        void Add(TransgerLogModel transgerLog); 
    }
}
