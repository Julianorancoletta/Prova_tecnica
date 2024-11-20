using Branef.Domain.Entity;
using Branef.Domain.Interfaces;
using Branef.Infrastructure.Context;

namespace Branef.Infrastructure.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BranefDbContext context) : base(context) { }
    }
}
