using ErrorOr;
using MediatR;

namespace Application.Objects.Productos.Create;

public record CreateProductoCommand(
    string id,
    string nombre,
    double precio,
    string descripcion
) : IRequest<ErrorOr<Unit>>;