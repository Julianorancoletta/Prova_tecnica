using Branef.Application.Features.Clientes.Events;
using Branef.Domain.Interfaces;
using Branef.Worker.Convert;
using MassTransit;

namespace Branef.Worker.Service
{
    public class ConsumerCliente : IConsumer<ClienteEvent>
    {
        private readonly IClienteMongoRepositorio _clienteMongoRepositorio;
        public ConsumerCliente(IClienteMongoRepositorio clienteMongoRepositorio) 
        {
            _clienteMongoRepositorio = clienteMongoRepositorio;
        }
        public async Task Consume(ConsumeContext<ClienteEvent> context)
        {
            var cliente = context.Message.Convertcliente();

            switch (context.Message.ETipoFIla)
            {
                case Domain.Enums.ETipoFIla.create:
                    await _clienteMongoRepositorio.CreateAsync(cliente);
                    break;
                case Domain.Enums.ETipoFIla.update:
                    await _clienteMongoRepositorio.UpdateAsync(cliente.Id, cliente);
                    break;
                case Domain.Enums.ETipoFIla.delete:
                    await _clienteMongoRepositorio.RemoveAsync(cliente.Id);
                    break;
                default:
                    break;
            }
        }
    }
}
