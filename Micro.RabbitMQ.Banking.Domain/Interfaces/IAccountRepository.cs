using Micro.RabbitMQ.Banking.Api.Domain.Models;

namespace Micro.RabbitMQ.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
