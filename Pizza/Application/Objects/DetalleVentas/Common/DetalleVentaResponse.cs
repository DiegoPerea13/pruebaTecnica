namespace DetalleVentas.Common;

public record DetalleVentaResponse(

        Guid id,
        Guid productoId,
        Guid ventaId,
        int cantidad,
        double precioUnitario,
        double total
);