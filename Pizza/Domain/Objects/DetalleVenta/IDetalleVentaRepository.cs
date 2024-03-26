using Domain.Objects.Venta;

namespace Domain.Objects.DetalleVenta;

public interface IDetalleVentaRepository
{

    Task<List<DetalleVenta>> GetByVentaId(VentaId id);
    Task<List<DetalleVenta>> GetById(VentaId ventaId, DetalleVentaId id);
    void Add(DetalleVenta detalleVenta);
    void Update(DetalleVenta detalleVenta);
    void Delete(DetalleVenta detalleVenta);

}