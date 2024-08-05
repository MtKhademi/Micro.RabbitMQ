using MediatR;
using Micro.RabbitMQ.Domain.Core.Bus;
using Micro.RabbitMQ.Domain.Core.Commands;
using Micro.RabbitMQ.Domain.Core.Events;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Micro.RabbitMQ.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;


        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = [];
            _eventTypes = [];
        }


        public  Task SendCommand<TCommand>(TCommand command) where TCommand : Command
        {
            return _mediator.Send(command);
        }


        public void Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.VirtualHost = "/";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";

            using (var connecgion = factory.CreateConnection())
            using (var channel = connecgion.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonSerializer.Serialize(@event);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);

            }

        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);


            if (!_eventTypes.Contains(typeof(T)))
                _eventTypes.Add(typeof(T));


            if (!_handlers.ContainsKey(eventName))
                _handlers.Add(eventName, new List<Type>());


            if (_handlers[eventName].Any(x => x.GetType() == handlerType))
            {
                throw new ArgumentException(
                    $"the handler type {handlerType.Name} already registed for" +
                    $" '{eventName}'", nameof(handlerType));
            }


            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }

        private void StartBasicConsume<T>() where T : Event
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.VirtualHost = "/";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";

            factory.DispatchConsumersAsync = true; //????

            var connecgion = factory.CreateConnection();
            var channel = connecgion.CreateModel();
            {
                var queueName = typeof(T).Name;

                channel.QueueDeclare(queueName, false, false, false, null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;

                channel.BasicConsume(queueName, true, consumer);
            }
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                await ProccessEventAsync(eventName, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task ProccessEventAsync(string eventName, string message)
        {
            if (!_handlers.ContainsKey(eventName))
                return;

            var subscriptions = _handlers[eventName];
            foreach (var subscription in subscriptions)
            {
                var handler = Activator.CreateInstance(subscription);
                if (handler is null) continue;


                var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);

                var @event = Newtonsoft.Json.JsonConvert.DeserializeObject(message, eventType);


                //var @event = JsonSerializer.Serialize(message, eventType);

                var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);


                await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });

            }
        }
    }
}
