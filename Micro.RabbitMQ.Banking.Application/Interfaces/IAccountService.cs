using Micro.RabbitMQ.Banking.Api.Domain.Models;

namespace Micro.RabbitMQ.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
