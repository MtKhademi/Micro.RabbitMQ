using Micro.RabbitMQ.Transfer.Data.Context;
using Micro.RabbitMQ.Transfer.Domain.Interfaces;
using Micro.RabbitMQ.Transfer.Domain.Models;

namespace Micro.RabbitMQ.Transfer.Data.Repositories
{
    public class TransgerLogRepository
        (TransferContext context) : ITransferLogRepository
    {
        public void Add(TransgerLogModel transgerLog)
        {
            context.TransferLogs.Add(transgerLog);
            context.SaveChanges();
        }

        public IEnumerable<TransgerLogModel> Gets()
        {
            return context.TransferLogs;
        }
    }
}
