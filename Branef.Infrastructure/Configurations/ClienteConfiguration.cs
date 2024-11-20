using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Branef.Domain.Entity;

namespace Branef.Infrastructure.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeEmpresa)
               .IsRequired();

            builder.Property(c => c.Porte)
               .IsRequired()
               .HasConversion<int>();

            builder.ToTable("Clientes");
        }


    }
}
