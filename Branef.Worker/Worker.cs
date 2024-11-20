using Branef.Domain.Entity;
using Branef.Worker.Service;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branef.Worker
{
    internal class Worker : BackgroundService 
    {
        private readonly IConsumerCliente _consumerCliente;

        public Worker() { }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
        }

        
    }
}
