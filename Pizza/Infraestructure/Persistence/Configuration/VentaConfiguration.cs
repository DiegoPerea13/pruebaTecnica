using Domain.Objects.Venta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using  Domain.Objects.Cliente;
namespace Infraestructure.Persistence.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Ventas");
        builder.HasKey(v => v.id);
        builder.Property(v => v.id).HasConversion(
            ventaId => ventaId.Value,    
            value => new VentaId(value)
        );
        builder.Property(v => v.clienteId).HasConversion(
            clienteId => clienteId.Value,    
            value => new ClienteId(value)
        );
    }
}