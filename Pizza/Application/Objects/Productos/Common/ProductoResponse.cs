namespace Productos.Common;

public record ProductoResponse(

        Guid id,
        string nombre,
        double precio,
        string descripcion
);