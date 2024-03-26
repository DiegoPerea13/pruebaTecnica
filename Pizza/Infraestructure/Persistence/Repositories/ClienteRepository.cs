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
    public Task<List<Cliente>> GetAll() 
    {
        throw new NotImplementedException();
    }
    public Task<Cliente?> GetById(ClienteId id)
    {
        throw new NotImplementedException();
    }
    public void Update(Cliente cliente)=> _context.clientes.Update(cliente);
}