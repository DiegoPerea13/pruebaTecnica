using ErrorOr;
using MediatR;
namespace Application.Objects.Ventas.Delete;

public record DeleteVentaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;