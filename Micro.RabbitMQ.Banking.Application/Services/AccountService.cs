using Micro.RabbitMQ.Banking.Api.Domain.Models;
using Micro.RabbitMQ.Banking.Application.Interfaces;
using Micro.RabbitMQ.Banking.Application.Models;
using Micro.RabbitMQ.Banking.Domain.Commands;
using Micro.RabbitMQ.Banking.Domain.Interfaces;
using Micro.RabbitMQ.Domain.Core.Bus;

namespace Micro.RabbitMQ.Banking.Application.Services
{
    public class AccountService(
        IAccountRepository accountRepository,
        IEventBus eventBus) : IAccountService
    {
        public IEnumerable<Account> GetAccounts()
            => accountRepository.GetAccounts();

        public void TransferFunds(AccountTransfer accountTransfer)
        {

            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount);

            eventBus.SendCommand(createTransferCommand);
         }
    }
}
