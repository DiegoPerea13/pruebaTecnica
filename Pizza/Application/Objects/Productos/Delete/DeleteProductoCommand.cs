using ErrorOr;
using MediatR;
namespace Application.Objects.Productos.Delete;

public record DeleteProductoCommand(Guid Id) : IRequest<ErrorOr<Unit>>;