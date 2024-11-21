using Branef.Application.Convert;
using Branef.Application.Service;
using Branef.Domain.Interfaces;
using MediatR;
using System.Diagnostics;

namespace Branef.Application.Features.Clientes.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteEvent>
    {

        private readonly IFilaService _bus;
        private readonly IClienteMongoRepositorio _clienteMongoRepositorio;

        public ClienteEventHandler(IFilaService bus, IClienteMongoRepositorio clienteMongoRepositorio)
        {
            _bus = bus;
            _clienteMongoRepositorio = clienteMongoRepositorio;
        }

        public async Task Handle(ClienteEvent message, CancellationToken cancellationToken)
        {
            await _bus.PublicarFila(message);

        }
    }
}
