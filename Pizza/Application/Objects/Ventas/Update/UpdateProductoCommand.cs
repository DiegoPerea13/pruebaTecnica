using ErrorOr;
using MediatR;

namespace Application.Objects.Ventas.Update;

public record UpdateVentaCommand(
    Guid id,
    Guid clienteId,
    string fecha,
    double total
): IRequest<ErrorOr<Unit>>;