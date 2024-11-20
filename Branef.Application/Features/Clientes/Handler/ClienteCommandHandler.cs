using MediatR;
using Branef.Application.Features.Clientes.Commands;
using FluentValidation;
using Branef.Application.Exceptions;
using Branef.Domain.Interfaces;
using Branef.Application.Convert;
using Branef.Application.Features.Clientes.Events;
using Branef.Domain.Enums;


namespace Branef.Application.Features.Clientes.Handler
{
    public class ClienteCommandHandler :
        IRequestHandler<AdicionarClienteCommand, Guid>,
        IRequestHandler<AtualizarClienteCommand, Guid>,
        IRequestHandler<RemoverClienteCommand, Guid>
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteCommandHandler(
            IClienteRepository clienteRepository,
            IMediator mediator)
        {

            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(AdicionarClienteCommand message, CancellationToken cancellationToken)
        {
            //Validar os dados inseridos
            var validator = new AdicionarClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(message);

            if (validationResult.Errors.Any())
                throw new BadRequestException("erro", validationResult);

            var cliente = message.Convertcliente();

            await _clienteRepository.Adicionar(cliente);

            await _mediator.Publish(new ClienteEvent(
                cliente.Id,
                cliente.NomeEmpresa,
                cliente.Porte,
                ETipoFIla.create
                ), cancellationToken);
            return cliente.Id;
        }

        public async Task<Guid> Handle(AtualizarClienteCommand message, CancellationToken cancellationToken)
        {
            //Validar os dados inseridos
            var validator = new AtualizarClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(message);

            if (validationResult.Errors.Any())
                throw new BadRequestException("erro", validationResult);

            var cliente = message.Convertcliente();

            await _clienteRepository.Remover(cliente);

            await _mediator.Publish(new ClienteEvent(
                cliente.Id,
                cliente.NomeEmpresa,
                cliente.Porte,
                ETipoFIla.delete
                ), cancellationToken);

            return cliente.Id;

        }

        public async Task<Guid> Handle(RemoverClienteCommand message, CancellationToken cancellationToken)
        {
            //Validar os dados inseridos
            var validator = new RemoverClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(message);

            if (validationResult.Errors.Any())
                throw new BadRequestException("erro", validationResult);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Erro na atualização ", validationResult);

            var cliente = message.Convertcliente();

            await _clienteRepository.Atualizar(cliente);

            await _mediator.Publish(new ClienteEvent(
                cliente.Id,
                cliente.NomeEmpresa,
                cliente.Porte,
                ETipoFIla.update
                ), cancellationToken);

            return cliente.Id;

        }


    }
}
