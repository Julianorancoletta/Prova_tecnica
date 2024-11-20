using Branef.Domain.Enums;
using FluentValidation;
using MediatR;

namespace Branef.Application.Features.Clientes.Commands
{
    public class AtualizarClienteCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string NomeEmpresa { get; init; }
        public EPorte Porte { get; init; }

    }

    public class AtualizarClienteCommandValidator : AbstractValidator<AtualizarClienteCommand>
    {
        public AtualizarClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.NomeEmpresa)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.Porte)
                .IsInEnum().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }

}
