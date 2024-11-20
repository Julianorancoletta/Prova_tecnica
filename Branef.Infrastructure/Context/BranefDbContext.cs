

using Branef.Domain.Entity;
using Branef.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Branef.Infrastructure.Context
{
    public class BranefDbContext : DbContext, IUnitOfWork
    {
        public BranefDbContext(DbContextOptions<BranefDbContext> options)
        : base(options)
        { }

        public DbSet<Cliente> clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BranefDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
               .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }
}
