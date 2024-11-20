using Branef.Domain.Entity;

namespace Branef.Domain.Interfaces
{
    public interface IClienteMongoRepositorio
    {
        public Task<List<Cliente>> GetAsync();

        public Task<Cliente> GetAsync(Guid id);

        public Task CreateAsync(Cliente Cliente);

        public Task UpdateAsync(Guid id, Cliente Cliente);

        public Task RemoveAsync(Guid id);
    }
}