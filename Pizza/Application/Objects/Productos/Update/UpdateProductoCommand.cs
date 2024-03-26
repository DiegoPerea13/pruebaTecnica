using ErrorOr;
using MediatR;

namespace Application.Objects.Productos.Update;

public record UpdateProductoCommand(
    Guid id, 
    string nombre,
    int precio,
    string descripcion
): IRequest<ErrorOr<Unit>>;