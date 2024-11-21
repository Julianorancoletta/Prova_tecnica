using Branef.Application.Features.Clientes.Events;
using Branef.Domain.Entity;

namespace Branef.Worker.Convert
{
    public static class ToClienteConvert
    {
        public static Cliente Convertcliente(this ClienteEvent command) => new(
           command.NomeEmpresa,
           command.Porte,
           command.Id);
    }
}
