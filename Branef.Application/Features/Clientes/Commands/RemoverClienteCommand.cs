using Branef.Domain.Enums;
using FluentValidation;
using MediatR;

namespace Branef.Application.Features.Clientes.Commands
{
    public class RemoverClienteCommand : IRequest<Guid>
    {

        public Guid Id { get; set; }

    }

    public class RemoverClienteCommandValidator : AbstractValidator<RemoverClienteCommand>
    {
        public RemoverClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }


}
