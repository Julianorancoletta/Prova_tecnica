using Branef.Domain.Enums;
using MediatR;

namespace Branef.Application.Features.Clientes.Events
{
    public class ClienteEvent : INotification
    {
        public ClienteEvent(Guid id, string nomeEmpresa, EPorte porte, ETipoFIla eTipoFIla)
        {
            Id = id;
            NomeEmpresa = nomeEmpresa;
            Porte = porte;
            ETipoFIla = eTipoFIla;
        }

        public Guid Id { get; set; }
        public string NomeEmpresa { get; init; }
        public EPorte Porte { get; init; }
        public ETipoFIla ETipoFIla { get; init; }
    }
}
