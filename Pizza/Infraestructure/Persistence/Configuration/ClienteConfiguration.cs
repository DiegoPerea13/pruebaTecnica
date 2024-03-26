using Domain.Objects.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configuration;

public class ClienteConfiguuration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(c => c.id);

        builder.Property(c => c.id).HasConversion(
            clienteId => clienteId.Value,    
            value => new ClienteId(value)
        );

    }
}
