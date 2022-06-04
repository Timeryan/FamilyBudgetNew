using EmailService;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("rabbitmq");
    cfg.ReceiveEndpoint("send-email-queue", e =>
    {
        e.Consumer<SendEmailConsumer>();
    });
});

await busControl.StartAsync();
Console.WriteLine("Consumers is start");

app.Run();