using System.ComponentModel.DataAnnotations;
using Domain.Objects.Cliente;
using Domain.Primitives;

namespace Domain.Objects.Venta;

public sealed class Venta : AggregateRoot
{

    public Venta(VentaId id, ClienteId clienteId, string fecha, double total)
    {
        this.id = id;
        this.clienteId = clienteId;
        this.fecha = fecha;
        this.total = total;
    }
    public Venta()
    {
    }
    public VentaId id { get; private set; }

    public ClienteId clienteId { get; private set; }

    public string fecha { get; private set; } = string.Empty;

    public double total { get; private set; }

    public static Venta UpdateVenta(Guid id, Guid clienteID, string fecha, double total)
    {
        return new Venta(new VentaId(id), new ClienteId(clienteID), fecha, total);
    }
}