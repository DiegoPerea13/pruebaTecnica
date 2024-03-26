namespace Clientes.Common;

public record ClienteResponse(

        Guid id,
        string nombre,
        int dni
);