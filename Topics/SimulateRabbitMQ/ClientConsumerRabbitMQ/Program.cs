using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Internal;
using RabbitMQ.Client;
using System.Text;
var builder = WebHost.CreateDefaultBuilder(args).UseStartup<myStartUp>()
    .UseKestrel().Build();
builder.Run();

 class myStartUp
{
    public void Configure(IApplicationBuilder applicationBuilder,
           IHostingEnvironment hostingEnvironment)
    {
        applicationBuilder.Map("/publish",publishMessage);
        Console.WriteLine("start Server");
    }

    private void publishMessage(IApplicationBuilder builder)
    {
        builder.Use(async (c, r) =>
        {
            var factory = new ConnectionFactory();
            factory.ClientProvidedName = "Producer 1";
            factory.Uri = new Uri("amqp://user:password@localhost:5672");
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            string ExchangeName = "exchange-messages";
            string routingKey = "exchange-key";
            string queueName = "queue-name";
            channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, ExchangeName, routingKey);
            byte[] message = Encoding.UTF8.GetBytes("First Message Produced To Queue");
            channel.BasicPublish(ExchangeName, routingKey, false, null, message);
            channel.Close();
            connection.Close();
            await c.Response.WriteAsync("published successfully");
        });
    }
}