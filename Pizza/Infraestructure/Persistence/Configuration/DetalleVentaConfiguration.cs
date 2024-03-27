using Domain.Objects.DetalleVenta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Objects.Producto;
using Domain.Objects.Venta;
namespace Infraestructure.Persistence.Configuration;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("DetalleVentas");
        builder.HasKey(d => d.id);

        builder.Property(d => d.id).HasConversion(
            detalleId => detalleId.Value,
            value => new DetalleVentaId(value)
        );
        builder.Property(d => d.idVenta).HasConversion(
            ventaId => ventaId.Value,
            value => new VentaId(value)
        );
        builder.Property(d => d.idProducto).HasConversion(
            productoId => productoId.Value,
            value => new ProductoId(value)
        );
    }
}