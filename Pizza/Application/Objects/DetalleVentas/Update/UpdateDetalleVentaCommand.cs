using ErrorOr;
using MediatR;

namespace Application.Objects.DetalleVentas.Update;

public record UpdateDetalleVentaCommand(
    Guid id,
    Guid productoId,
    Guid ventaId,
    int cantidad,
    double precioUnitario,
    double total
): IRequest<ErrorOr<Unit>>;