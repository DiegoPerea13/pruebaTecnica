using Domain.Objects.Producto;
using Domain.Objects.Venta;
using Domain.Primitives;

namespace Domain.Objects.DetalleVenta;

public sealed class DetalleVenta : AggregateRoot
{

    public DetalleVenta(DetalleVentaId id, ProductoId idProducto, VentaId idVenta, int cantidad, double precioUnitario, double total)
    {
        this.id = id;
        this.idProducto = idProducto;
        this.idVenta = idVenta;
        this.cantidad = cantidad;
        this.precioUnitario = precioUnitario;
        this.total = total;
    }

    public DetalleVenta()
    {
    }

    public DetalleVentaId id { get; private set; }

    public ProductoId idProducto { get; private set; }

    public VentaId idVenta { get; private set; }

    public int cantidad { get; private set; }

    public double precioUnitario { get; private set; }

    public double total { get; private set; }
    public static DetalleVenta UpdateDetalleVenta(Guid id, Guid productoId, Guid ventaId, int cantidad, double precioUnitario, double total)
    {
        return new DetalleVenta(new DetalleVentaId(id), new ProductoId(productoId), new VentaId(ventaId), cantidad, precioUnitario, total);
    }
}