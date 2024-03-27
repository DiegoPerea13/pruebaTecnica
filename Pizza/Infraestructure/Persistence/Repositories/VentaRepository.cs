using Domain.Objects.Venta;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class VentaRepository : IVentaRepository
{
    private readonly ApplicationDbContext _context;
    public VentaRepository(ApplicationDbContext context)
    {
        _context = context?? throw new ArgumentNullException(nameof(context));
    }
    public void Add(Venta venta) => _context.ventas.Add(venta);
    public void Delete(Venta venta) => _context.ventas.Remove(venta);
    public async Task<bool> ExistsAsync(VentaId id) => await _context.ventas.AnyAsync(v => v.id == id);
    public async Task<List<Venta>> GetAll() => await _context.ventas.ToListAsync();
    public async Task<Venta?> getById(VentaId id)=> await _context.ventas.SingleOrDefaultAsync(v => v.id == id);
    public void Update(Venta venta)=> _context.ventas.Update(venta);
}
