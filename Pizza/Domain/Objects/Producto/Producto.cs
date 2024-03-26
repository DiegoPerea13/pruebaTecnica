using Domain.Primitives;

namespace Domain.Objects.Producto;

public sealed class Producto : AggregateRoot
{

    public Producto(ProductoId id, string nombre, double precio, string descripcion)
    {
        this.id = id;
        this.nombre = nombre;
        this.precio = precio;
        this.descripcion = descripcion;
    }

    public Producto()
    {
    }

    public ProductoId id { get; private set; }

    public string nombre { get; private set; } = string.Empty;

    public double precio { get; private set; }

    public string descripcion { get; private set; } = string.Empty;
    public static Producto UpdateProducto(Guid id, string nombre, double precio, string descripcion)
    {
        return new Producto(new ProductoId(id), nombre, precio, descripcion);
    }
}
