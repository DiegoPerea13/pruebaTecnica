using Domain.Objects.Producto;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly ApplicationDbContext _context;
    public ProductoRepository(ApplicationDbContext context)
    {
        _context = context?? throw new ArgumentNullException(nameof(context));
    }
    public void Add(Producto producto) => _context.productos.Add(producto);
    public void Delete(Producto producto) => _context.productos.Remove(producto);
    public async Task<bool> ExistsAsync(ProductoId id)=> await _context.productos.AnyAsync(prod => prod.id == id);
    public async Task<List<Producto>> GetAll() => await _context.productos.ToListAsync();
    public async Task<Producto?> GetById(ProductoId id) => await _context.productos.SingleOrDefaultAsync(p => p.id == id);
    public void Update(Producto producto) => _context.productos.Update(producto);
}