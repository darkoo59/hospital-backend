using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Service;
using IntegrationLibrary.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IntegrationLibrary.Features.ManagerNotification.DTO;

namespace IntegrationLibrary.Features.ManagerNotification.Service
{
    public class RabbitMQNotificationService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        IServiceScopeFactory _serviceProvider;
        private readonly RabbitMQNotificationSettings _rabbitMQSettings;

        public RabbitMQNotificationService(IServiceScopeFactory serviceScopeFactory, IOptions<RabbitMQNotificationSettings> rabbitSettings)
        {
            this._serviceProvider = serviceScopeFactory;
            this._rabbitMQSettings = rabbitSettings.Value;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            string hostname = _rabbitMQSettings.HostName;
            var factory = new ConnectionFactory { HostName = _rabbitMQSettings.HostName };

            // create connection  
            _connection = factory.CreateConnection();

            // create channel  
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _rabbitMQSettings.QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                // received message  
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);

                // handle the received message 
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<IManagerNotificationService>();
                    HandleMessage(jsonMessage, context);
                }
            };

            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume(queue: _rabbitMQSettings.QueueName,
                autoAck: true,
                consumer: consumer);
            return Task.CompletedTask;
        }

        private void HandleMessage(string content, IManagerNotificationService _notificationService)
        {
            ReceivedNotificationDTO receivedNotification = JsonConvert.DeserializeObject<ReceivedNotificationDTO>(content);
            _notificationService.ReceiveNotification(receivedNotification);
        }

        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e) { }
        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerRegistered(object sender, ConsumerEventArgs e) { }
        private void OnConsumerShutdown(object sender, ShutdownEventArgs e) { }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e) { }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
