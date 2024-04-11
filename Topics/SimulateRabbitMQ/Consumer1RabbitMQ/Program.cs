
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var server = WebHost.CreateDefaultBuilder().UseStartup<StartUp>()
    .UseKestrel(options =>
    {
        options.ListenLocalhost(5555);
    }).Build();
server.Run();


class StartUp
{
    public void Configure(IApplicationBuilder applicationBuilder,
          IHostingEnvironment hostingEnvironment)
    {
        applicationBuilder.Map("/consume", publishMessage);
        Console.WriteLine("start Server");
    }

    private void publishMessage(IApplicationBuilder builder)
    {
        builder.Use(async (context, req) =>
        {
            var factory = new ConnectionFactory();
            factory.ClientProvidedName = "Consumer 1";
            factory.Uri = new Uri("amqp://user:password@localhost:5672");
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            string ExchangeName = "exchange-messages";
            string routingKey = "exchange-key";
            string queueName = "queue-name";
            channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, false, false, null);
            channel.QueueDeclare(queueName, false, false, false);
            channel.QueueBind(queueName, ExchangeName,routingKey);
            channel.BasicQos(0, 1, true);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async(sender, message) =>
            {
                var response = Encoding.UTF8.GetString(message.Body.ToArray());

                await context.Response.WriteAsync("Consumed Message : "+ response);
                channel.BasicAck(message.DeliveryTag,false);

            };
            var consumerTag = channel.BasicConsume(queueName, false, consumer);
            //channel.BasicCancel(consumerTag);
            //channel.Close();
            //connection.Close();
            await context.Response.WriteAsync("Consumed Message");
        });
    }
}