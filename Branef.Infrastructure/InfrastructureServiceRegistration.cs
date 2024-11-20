using Branef.Domain.Interfaces;
using Branef.Infrastructure.Context;
using Branef.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Branef.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Repository
            services.AddScoped<BranefDbContext>();
            services.AddScoped<IClienteMongoRepositorio, ClienteMongoRepositorio>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            return services;
        }
    }
}
