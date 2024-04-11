using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

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
channel.QueueBind(queueName, ExchangeName, routingKey);
channel.BasicQos(0, 1, true);

var consumer = new EventingBasicConsumer(channel);
consumer.Received +=  (sender, message) =>
{
    var response = Encoding.UTF8.GetString(message.Body.ToArray());

    Console.WriteLine("Consumed Message : " + response);
    channel.BasicAck(message.DeliveryTag, false);
};
var consumerTag = channel.BasicConsume(queueName, false, consumer);
Console.ReadLine();
channel.BasicCancel(consumerTag);
channel.Close();
connection.Close();