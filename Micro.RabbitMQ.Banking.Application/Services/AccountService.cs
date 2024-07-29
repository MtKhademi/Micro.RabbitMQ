using Micro.RabbitMQ.Banking.Api.Domain.Models;
using Micro.RabbitMQ.Banking.Application.Interfaces;
using Micro.RabbitMQ.Banking.Domain.Interfaces;

namespace Micro.RabbitMQ.Banking.Application.Services
{
    public class AccountService(IAccountRepository accountRepository) : IAccountService
    {
        public IEnumerable<Account> GetAccounts()
            => accountRepository.GetAccounts();
    }
}
