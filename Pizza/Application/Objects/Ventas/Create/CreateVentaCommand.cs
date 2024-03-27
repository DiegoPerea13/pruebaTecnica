using ErrorOr;
using MediatR;

namespace Application.Objects.Ventas.Create;

public record CreateVentaCommand(
    string id,
    string clienteId,
    string fecha,
    double total
) : IRequest<ErrorOr<Unit>>;