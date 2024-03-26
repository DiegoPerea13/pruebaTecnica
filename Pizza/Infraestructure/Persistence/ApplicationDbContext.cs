using Application.Data;
using Domain.Objects.Cliente;
using Domain.Objects.DetalleVenta;
using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    public DbSet<Cliente> clientes { get; set; }
    public DbSet<Producto> productos {get; set; }
    //public DbSet<Venta> ventas {get; set; }
    //public DbSet<DetalleVenta> detalleVentas {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {

        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e => e.GetDomainEvents());
        //Guarda cambios de bases
        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;

    }
}
