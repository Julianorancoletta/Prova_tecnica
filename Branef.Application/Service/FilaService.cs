using Branef.Application.Features.Clientes.Events;
using MassTransit;

namespace Branef.Application.Service
{
    public class FilaService : IFilaService
    {
        private readonly IBus _bus;

        public FilaService(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublicarFila(ClienteEvent clienteEvent)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:ConsumerCliente"));
            await endpoint.Send(clienteEvent);
        }
    }
}
