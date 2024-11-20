using HealthMedScheduler.Application;
using Branef.api.Configuration;
using Branef.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiConfig(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddSerilogConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

app.Run();