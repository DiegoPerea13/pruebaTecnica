using Domain.Objects.Producto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infraestructure.Persistence.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");
        builder.HasKey(p => p.id);

        builder.Property(p => p.id).HasConversion(
            productoId => productoId.Value,    
            value => new ProductoId(value)
        );
    }
}