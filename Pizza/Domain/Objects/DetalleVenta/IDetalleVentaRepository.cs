using Domain.Objects.Venta;

namespace Domain.Objects.DetalleVenta;

public interface IDetalleVentaRepository
{

    Task<List<DetalleVenta>> GetByVentaId(VentaId id);
    Task<DetalleVenta> GetById(VentaId ventaId, DetalleVentaId id);
    Task<bool> ExistsAsync(DetalleVentaId id);
    void Add(DetalleVenta detalleVenta);
    void Update(DetalleVenta detalleVenta);
    void Delete(DetalleVenta detalleVenta);

}