using Branef.api.Controllers;
using Branef.Application.Features.Clientes.Commands;
using Branef.Application.Features.Clientes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Health.Med.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : MainController<ClienteController>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public ClienteController(ILogger<ClienteController> logger, IMediator mediator) : base(logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Obtém todos os cliente.
        /// </summary>
        /// <returns>Uma lista de cliente.</returns>
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var agendamentos = await _mediator.Send(new ObterClienteQuery());
            return CustomResponse(agendamentos);
        }

        /// <summary>
        /// Obtém um cliente por ID.
        /// </summary>
        /// <param name="id">O ID do cliente.</param>
        /// <returns>O cliente nao encontrado ou um erro 404 se não encontrado.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            return CustomResponse(await _mediator.Send(new ObterClientePorIdQuery(id)));
        }


        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>O cliente foi adicionado ou um erro 400 em caso de falha na adição.</returns>
        [HttpPost("Cadastrar")]
        public async Task<ActionResult> Adicionar(AdicionarClienteCommand cliente)
        {
            return CreatedAtAction(nameof(ObterTodos), new { id = await _mediator.Send(cliente) });
        }

        /// <summary>
        /// atulizar um cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>O cliente foi adicionado ou um erro 400 em caso de falha na adição.</returns>
        [HttpPut("atulizar")]
        public async Task<ActionResult> atulizar(AtualizarClienteCommand cliente)
        {
            return CreatedAtAction(nameof(ObterTodos), new { id = await _mediator.Send(cliente) });
        }


        /// <summary>
        /// Remover cliente por ID.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Um código 201 em caso de sucesso no remocao ou um erro 400 em caso de falha.</returns>
        [HttpDelete]
        public async Task<ActionResult> Cancelar(RemoverClienteCommand cliente)
        {
            return CreatedAtAction(nameof(ObterTodos), new { id = await _mediator.Send(cliente) });
        }
    }
}
