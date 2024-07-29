using Micro.RabbitMQ.Banking.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro.RabbitMQ.Banking.Api.Data.Context
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }


        public DbSet<Account> Accounts { get; set; }

    }
}
