using Branef.Domain.Interfaces;
using Branef.Domain.Settings;
using Branef.Infrastructure.Repository;
using Branef.Worker;
using Delivery.Email.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services
        .AddMessageBus(hostContext.Configuration)
        .AddScoped<IClienteMongoRepositorio, ClienteMongoRepositorio>()
        .Configure<ClienteDatabaseSettings>(hostContext.Configuration.GetSection("ClienteDatabase"))
        .AddHostedService<Worker>();

    })
    .Build()
    .RunAsync();

