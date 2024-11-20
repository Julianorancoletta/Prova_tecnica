using Branef.Domain.Entity;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branef.Worker.Service
{
    public class ConsumerCliente : IConsumer<Cliente> , IConsumerCliente
    {
        public Task Consume(ConsumeContext<Cliente> context)
        {
            return Task.CompletedTask;
        }
    }
}
