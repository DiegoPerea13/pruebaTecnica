using Domain.Objects.Cliente;
using Domain.Objects.DetalleVenta;
using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Cliente> clientes { get; set; }
    DbSet<Producto> productos { get; set; }
    DbSet<Venta> ventas { get; set; }
    DbSet<DetalleVenta> detalleVentas { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}