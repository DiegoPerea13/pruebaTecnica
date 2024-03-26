using Domain.Objects.DetalleVenta;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infraestructure.Persistence.Configuration;

// public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
// {
//     public void Configure(EntityTypeBuilder<DetalleVenta> builder)
//     {
//         builder.ToTable("DetalleVentas");
//         builder.HasKey(d => d.id);

//         builder.Property(d => d.id).HasConversion(
//             detalleId => detalleId.Value,    
//             value => new DetalleVentaId(value)
//         );
//     }
// }