namespace Ventas.Common;

public record VentaResponse(

        Guid id,
        Guid clienteid,
        string fecha,
        double total
);