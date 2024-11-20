using Branef.Application.Features.Clientes.Events;

namespace Branef.Application.Service
{
    public interface IFilaService
    {
       Task PublicarFila(ClienteEvent clienteEvent);
    }
}
