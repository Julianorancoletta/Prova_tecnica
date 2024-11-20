using Branef.Domain.Entity;
using MediatR;

namespace Branef.Application.Features.Clientes.Queries
{
    public record ObterClienteQuery : IRequest<IEnumerable<Cliente>>;
    public record ObterClientePorIdQuery(Guid id) : IRequest<Cliente>;
}
