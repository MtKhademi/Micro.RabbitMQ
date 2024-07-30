using Micro.RabbitMQ.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.RabbitMQ.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int FromAccount { get; protected set; }
        public int ToAccount { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
