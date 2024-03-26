using Productos.Common;
using ErrorOr;
using MediatR;

namespace Application.Productos.GetbyId;

public record GetProductoById(Guid Id) : IRequest<ErrorOr<ProductoResponse>>;