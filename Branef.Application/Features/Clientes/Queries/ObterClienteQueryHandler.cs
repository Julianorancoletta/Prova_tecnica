using MediatR;
using Microsoft.Extensions.Logging;
using Branef.Domain.Entity;
using Branef.Domain.Interfaces;

namespace Branef.Application.Features.Clientes.Queries
{
    public class ObterClienteQueryHandler :
     IRequestHandler<ObterClienteQuery, IEnumerable<Cliente>>,
     IRequestHandler<ObterClientePorIdQuery, Cliente>
    {
        private readonly IClienteMongoRepositorio _clienteRepository;
        private readonly ILogger<ObterClienteQueryHandler> _logger;

        public ObterClienteQueryHandler(IClienteMongoRepositorio clienteRepository, ILogger<ObterClienteQueryHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<Cliente>> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            //Obter dados do banco
            var data = await _clienteRepository.GetAsync();

            //Retorna a lista de clientesViewModel
            _logger.LogInformation("Lista de médicos foi retornada com sucesso");
            return data;
        }

        public async Task<Cliente> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            //Obter dados do banco
            var data = await _clienteRepository.GetAsync(request.id);

            //Retorna a lista de clientesViewModel
            _logger.LogInformation("cliente foi retornado com sucesso!");
            return data;
        }
    }
}
