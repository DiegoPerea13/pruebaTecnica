using Domain.Objects.Cliente;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Cliente> clientes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}