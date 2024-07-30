using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.RabbitMQ.Banking.Domain.Commands
{
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand(int from, int to, decimal ammount)
        {
            FromAccount = from;
            ToAccount = to;
            Amount = ammount;
        }
    }
}
