using Micro.RabbitMQ.Banking.Api.Domain.Models;
using Micro.RabbitMQ.Banking.Application.Models;

namespace Micro.RabbitMQ.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void TransferFunds(AccountTransfer accountTransfer);
    }
}
