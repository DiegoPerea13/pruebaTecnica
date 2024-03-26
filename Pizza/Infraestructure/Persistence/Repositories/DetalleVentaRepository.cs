using Domain.Objects.DetalleVenta;
using Domain.Objects.Venta;

namespace Infraestructure.Persistence.Repositories;

public class DetalleVentaRepository : IDetalleVentaRepository
{
    public void Add(DetalleVenta detalleVenta)
    {
        throw new NotImplementedException();
    }

    public void Delete(DetalleVenta detalleVenta)
    {
        throw new NotImplementedException();
    }

    public Task<List<DetalleVenta>> GetById(VentaId ventaId, DetalleVentaId id)
    {
        throw new NotImplementedException();
    }

    public Task<List<DetalleVenta>> GetByVentaId(VentaId id)
    {
        throw new NotImplementedException();
    }

    public void Update(DetalleVenta detalleVenta)
    {
        throw new NotImplementedException();
    }
}