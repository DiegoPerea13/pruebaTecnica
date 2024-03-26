using Productos.Common;
using ErrorOr;
using MediatR;

namespace Application.Productos.GetAll;

public record GetAllProductos() : IRequest<ErrorOr<IReadOnlyList<ProductoResponse>>>;