using System.Data;
using Domain.Objects.DetalleVenta;
using Domain.Objects.Venta;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class DetalleVentaRepository : IDetalleVentaRepository
{
    private readonly ApplicationDbContext _context;
    public DetalleVentaRepository(ApplicationDbContext context)
    {
        _context = context?? throw new ArgumentNullException(nameof(context));
    }
    public void Add(DetalleVenta detalleVenta) => _context.detalleVentas.Add(detalleVenta);
    public void Delete(DetalleVenta detalleVenta) => _context.detalleVentas.Remove(detalleVenta);
    public async Task<bool> ExistsAsync(DetalleVentaId id)=> await _context.detalleVentas.AnyAsync(detVent => detVent.id == id);
    public Task<List<DetalleVenta>> GetByVentaId(VentaId id)
    {
        throw new NotImplementedException();
    }

    //public async Task<List<DetalleVenta>> GetByVentaId(VentaId id) => await _context.detalleVentas.SingleOrDefaultAsync(dv => dv.id == id);
    public async Task<List<DetalleVenta>> GetById(VentaId ventaId, DetalleVentaId id)=> await _context.detalleVentas.ToListAsync();
    public void Update(DetalleVenta detalleVenta)=> _context.detalleVentas.Update(detalleVenta);

    Task<DetalleVenta> IDetalleVentaRepository.GetById(VentaId ventaId, DetalleVentaId id)
    {
        throw new NotImplementedException();
    }
}