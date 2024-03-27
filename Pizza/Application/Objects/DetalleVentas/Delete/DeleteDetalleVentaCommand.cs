
using ErrorOr;
using MediatR;
namespace Application.Objects.DetalleVentas.Delete;

public record DeleteDetalleVentaCommand(Guid Id, Guid ventaID) : IRequest<ErrorOr<Unit>>;