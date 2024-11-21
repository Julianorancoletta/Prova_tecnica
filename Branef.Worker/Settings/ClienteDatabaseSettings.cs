namespace Branef.Worker.Settings
{
    public class ClienteDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PessoaCollectionName { get; set; } = null!;
    }
}
