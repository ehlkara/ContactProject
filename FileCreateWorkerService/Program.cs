using Contact.Core.Context;
using FileCreateWorkerService;
using FileCreateWorkerService.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        IConfiguration Configuration = hostContext.Configuration; 

        services.AddSingleton<RabbitMQClientService>();
        services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri(Configuration.GetConnectionString("RabbitMQ")), DispatchConsumersAsync = true });
        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();
