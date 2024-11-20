using Branef.Domain.Enums;
using FluentValidation;
using MediatR;

namespace Branef.Application.Features.Clientes.Commands
{
    public class AdicionarClienteCommand : IRequest<Guid>
    {
        public string NomeEmpresa { get; init; }
        public EPorte Porte { get; init; } 
    }
    public class AdicionarClienteCommandValidator : AbstractValidator<AdicionarClienteCommand>
    {
        public AdicionarClienteCommandValidator()
        {

            RuleFor(x => x.NomeEmpresa)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.Porte)
                .IsInEnum().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
