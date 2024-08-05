using Micro.RabbitMQ.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro.RabbitMQ.Transfer.Data.Context
{
    public class TransferContext : DbContext
    {

        public TransferContext(DbContextOptions<TransferContext> options) :
            base(options)
        {

        }


        public DbSet<TransgerLogModel> TransferLogs { get; set; }

    }
}
