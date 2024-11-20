using Branef.Application.Features.Clientes.Commands;
using Branef.Application.Features.Clientes.Events;
using Branef.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branef.Application.Convert
{
    public static class ToClienteConvert
    {
        public static Cliente Convertcliente(this AdicionarClienteCommand command) => new(
           command.NomeEmpresa,
           command.Porte,
           Guid.NewGuid());

        public static Cliente Convertcliente(this AtualizarClienteCommand command) => new(
           command.NomeEmpresa,
           command.Porte,
           command.Id);

        public static Cliente Convertcliente(this RemoverClienteCommand command) => new(
           command.Id);

        public static Cliente Convertcliente(this ClienteEvent command) => new(
           command.NomeEmpresa,
           command.Porte,
           command.Id);
    }
}
