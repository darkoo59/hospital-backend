using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBankNews.Service
{
    public class RabbitMQService : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        IServiceScopeFactory _serviceProvider;
        private readonly RabbitMQSettings _rabbitMQSettings;

        public RabbitMQService(IServiceScopeFactory serviceScopeFactory, IOptions<RabbitMQSettings> rabbitSettings)
        {
            this._serviceProvider = serviceScopeFactory;
            this._rabbitMQSettings = rabbitSettings.Value;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {

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
                    var context = scope.ServiceProvider.GetRequiredService<IBankNewsService>();
                    HandleMessage(jsonMessage,context);
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

        private void HandleMessage(string content, IBankNewsService _bankNewsService)
        {  
            BankNews message = JsonConvert.DeserializeObject<BankNews>(content);
            message.State = NewsState.NEW;
            _bankNewsService.AddNews(message);
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
