using Branef.Domain.Entity;
using Branef.Domain.Interfaces;
using Branef.Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Branef.Infrastructure.Repository
{
    public class ClienteMongoRepositorio : IClienteMongoRepositorio
    {
        private readonly IMongoCollection<Cliente> _ClienteCollection;

        public ClienteMongoRepositorio(IOptions<ClienteDatabaseSettings> options)
        {
            var mongoDatabase = new MongoClient(options.Value.ConnectionString)
                .GetDatabase(options.Value.DatabaseName);

            _ClienteCollection = mongoDatabase.GetCollection<Cliente>(
                options.Value.PessoaCollectionName);
        }

        public async Task<List<Cliente>> GetAsync() =>
            await _ClienteCollection.Find(_ => true).ToListAsync();

        public async Task<Cliente> GetAsync(Guid id) =>
            await _ClienteCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente Cliente) =>
            await _ClienteCollection.InsertOneAsync(Cliente);

        public async Task UpdateAsync(Guid id, Cliente Cliente) =>
            await _ClienteCollection.ReplaceOneAsync(x => x.Id == id, Cliente);

        public async Task RemoveAsync(Guid id) =>
            await _ClienteCollection.DeleteOneAsync(x => x.Id == id);
    }
}
