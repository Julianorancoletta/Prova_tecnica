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
            var cliente = message.Convertcliente();

            switch (message.ETipoFIla)  
            {
                case Domain.Enums.ETipoFIla.create:
                    await _clienteMongoRepositorio.CreateAsync(cliente);
                    break;
                case Domain.Enums.ETipoFIla.update:
                    await _clienteMongoRepositorio.UpdateAsync(cliente.Id,cliente);
                    break;
                case Domain.Enums.ETipoFIla.delete:
                    await _clienteMongoRepositorio.RemoveAsync(cliente.Id);
                    break;
                default:
                    break;
            }


            //await _bus.PublicarFila(message);

        }
    }
}
