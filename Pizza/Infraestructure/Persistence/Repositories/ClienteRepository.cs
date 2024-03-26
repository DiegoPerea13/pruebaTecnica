using Domain.Objects.Cliente;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context?? throw new ArgumentNullException(nameof(context));
    }
    public void Add(Cliente cliente)=> _context.clientes.Add(cliente);
    public void Delete(Cliente cliente)=> _context.clientes.Remove(cliente);
     public async Task<bool> ExistsAsync(ClienteId id) => await _context.clientes.AnyAsync(customer => customer.id == id);
    public async Task<List<Cliente>> GetAll() => await _context.clientes.ToListAsync();
    public async Task<Cliente?> GetById(ClienteId id) => await _context.clientes.SingleOrDefaultAsync(c => c.id == id);
    public void Update(Cliente cliente)=> _context.clientes.Update(cliente);
}