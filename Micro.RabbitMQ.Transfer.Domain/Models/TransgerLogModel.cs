using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.RabbitMQ.Transfer.Domain.Models
{
    public class TransgerLogModel
    {
        public int Id { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }
        public decimal Ammount { get; set; }
    }
}
