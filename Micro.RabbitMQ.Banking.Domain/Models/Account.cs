namespace Micro.RabbitMQ.Banking.Api.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }

    }
}
