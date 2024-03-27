using ErrorOr;
using MediatR;

namespace Application.Objects.DetalleVentas.Create;

public record CreateDetalleVentaCommand(
    string id,
    string clienteId,
    string productoId,
    string ventaId,
    int cantidad,
    double precioUnitario,
    double total
) : IRequest<ErrorOr<Unit>>;