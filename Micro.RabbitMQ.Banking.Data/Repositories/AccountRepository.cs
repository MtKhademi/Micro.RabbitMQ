using Micro.RabbitMQ.Banking.Api.Data.Context;
using Micro.RabbitMQ.Banking.Api.Domain.Models;
using Micro.RabbitMQ.Banking.Domain.Interfaces;

namespace Micro.RabbitMQ.Banking.Data.Repositories;

public class AccountRepository(BankingContext context) : IAccountRepository
{
    public IEnumerable<Account> GetAccounts()
        => context.Accounts;
}
