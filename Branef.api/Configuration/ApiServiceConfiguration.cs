using Branef.Application.Service;
using Branef.Domain.Interfaces;
using Branef.Domain.Settings;
using Branef.Infrastructure.Context;
using Branef.Infrastructure.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Compact;
using System.Reflection;

namespace Branef.api.Configuration
{
    public static class ApiServiceConfiguration
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BranefDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFilaService, FilaService>();
            services.Configure<ClienteDatabaseSettings>(o => configuration.GetSection("ClienteDatabase").Bind(o));
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddControllers();

            return services;
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<BranefDbContext>();
                    dbContext.Database.Migrate();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {

                    Title = "Branef API",
                    Description = "",
                    Contact = new OpenApiContact() { Name = "Juliano", Email = "julio45.jr@gmail.com " }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        public static void AddSerilogConfiguration(this IServiceCollection services, IConfiguration configuration,
           IHostEnvironment environment)
        {
            var logConfig = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProperty("Application", "Branef")
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console(new CompactJsonFormatter())
                .CreateLogger();

            ILoggerProvider serilogProvider = new SerilogLoggerProvider(logConfig);

            services.AddSingleton(serilogProvider);
            services.AddSingleton<ILoggerFactory, LoggerFactory>(serviceProvider =>
            {
                var factory = new LoggerFactory();
                factory.AddProvider(serviceProvider.GetRequiredService<ILoggerProvider>());
                return factory;
            });
        }
    }

}

